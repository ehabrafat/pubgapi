using Microsoft.EntityFrameworkCore;
using PUBGAPI.Data;
using PUBGAPI.Dtos.Game;
using PUBGAPI.Dtos.GameMode;
using PUBGAPI.Dtos.Matches;
using PUBGAPI.Dtos.User;
using PUBGAPI.Interfaces;

namespace PUBGAPI.Services;

public class PlayerService : IPlayerService
{

    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly EfDbContext _dbContext;
    private readonly IGameService _gameService;
    private readonly IUserService _userService;

    public PlayerService(EfDbContext dbContext, IGameService gameService, IUserService userService)
    {
        _dbContext = dbContext;
        _gameService = gameService;
        _userService = userService;
    }

    public async Task<List<UserGameResponse>> GetGames(CancellationToken cancellationToken)
    {
        var user = _userService.GetCurrentUser();
        if (user is null) return [];
        var res = await _dbContext.Set<ConnectedGame>()
            .Where(x => x.UserId == user.Id)
            .Select(x => new UserGameResponse
            {
                Id = x.Game.Id,
                Name = x.Game.Name,
                Account = new UserGameAccountResponse
                {
                    AccountId = x.Account.AccountId
                }
            }).ToListAsync(cancellationToken);
        return res;
    }

    public async Task<List<UserMatchResponse>> GetLiveMatches(CancellationToken cancellationToken)
    {
        var user = _userService.GetCurrentUser() ?? throw new Exception("User Not Found");
        var matches = await _dbContext.Matches
            .Where(x => x.Status != "completed" && x.Players.Any(p => p.GameAccount.ConnectedGame.UserId == user.Id))
            .Select(x => new UserMatchResponse
            {
                Id = x.Id,
                RemPlayers = x.RemPlayers,
                Status = x.Status,
                EndedAt = x.EndedAt,
                CreatedAt = x.CreatedAt,
                Tournament = new Dtos.Tournament.TournamentResponse
                {
                    Id = x.Tournament.Id,
                    PrizePool = x.Tournament.PrizePool,
                    Name = x.Tournament.Name,
                    Ticket = x.Tournament.Ticket,
                    Mode = new GameModeResponse
                    {
                        Id = x.Tournament.GameMode.Id,
                        Name = x.Tournament.GameMode.Name,
                        Description = x.Tournament.GameMode.Description,
                        Game = new GameResponse
                        {
                            Name = x.Tournament.GameMode.Game.Name,
                            Id = x.Tournament.GameMode.Game.Id,
                        }
                    },
                },
                Players = x.Players.Select(p => new MatchPlayerResponse
                {
                    UserId = p.GameAccount.ConnectedGame.UserId,
                    Username = p.GameAccount.ConnectedGame.User.Username,
                    AccountId = p.GameAccount.AccountId,
                }).ToList()
            })
            .ToListAsync(cancellationToken);

        foreach (var match in matches)
        {
            foreach (var player in match.Players)
            {
                player.Performance =
                    await _gameService.GetPlayerPerformanceForTournament(match.Tournament.Id, player.AccountId, 
                        match.CreatedAt,
                        cancellationToken);
            }
        }

        return matches;
    }
}