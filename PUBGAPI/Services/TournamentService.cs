using Microsoft.EntityFrameworkCore;
using PUBGAPI.Data;
using PUBGAPI.Dtos.GameMode;
using PUBGAPI.Dtos.Tournament;
using PUBGAPI.Interfaces;
using PUBGAPI.Utils;

namespace PUBGAPI.Services;

public class TournamentService : ITournamentService
{
    private readonly EfDbContext _dbContext;
    private readonly IUserService _userService;

    public TournamentService(EfDbContext dbContext, IUserService userService)
    {
        _dbContext = dbContext;
        _userService = userService;
    }


    public async Task Join(int tournamentId, CancellationToken cancellationToken)
    {
        var user = _userService.GetCurrentUser() ?? throw new Exception("user not found");
        var gameId = await _dbContext.Tournaments.Where(x => x.Id == tournamentId)
            .Select(x => x.GameMode.GameId).FirstOrDefaultAsync(cancellationToken);
        if (gameId == 0) throw new Exception("Game Not Found");
        var connectedGame = await _dbContext.Set<ConnectedGame>().Where(x => x.UserId == user.Id && x.GameId == gameId)
            .Include(x => x.Account)
            .FirstOrDefaultAsync(cancellationToken) ?? throw new Exception("Not Connected To The GAME");
        TournamentQueue.Queue.Enqueue(new QueuePlayer
        {
            TournamentId = tournamentId,
            GameAccountId = connectedGame.Account.Id,
        });
    }

    public async Task<List<TournamentResponse>> GetAll(int gameId, CancellationToken cancellationToken)
    {
        var gameExists = await _dbContext.Games.AnyAsync(x => x.Id == gameId, cancellationToken);
        if (!gameExists) throw new Exception("Invalid Game Id");
        var tournaments = await _dbContext.Tournaments
            .Where(x => x.GameMode.GameId == gameId)
            .Select(x => new TournamentResponse
            {
                Id = x.Id,
                Name = x.Name,
                Ticket = x.Ticket,
                PrizePool = x.PrizePool,
                Players = x.Players,
                Mode = new GameModeResponse
                {
                    Id = x.GameMode.Id,
                    Name = x.GameMode.Name,
                }
            }).ToListAsync(cancellationToken);
        return tournaments;
    }
}