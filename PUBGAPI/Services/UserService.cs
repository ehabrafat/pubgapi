using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using PUBGAPI.Data;
using PUBGAPI.Dtos.User;
using PUBGAPI.Interfaces;

namespace PUBGAPI.Services;

public class UserService : IUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly EfDbContext _dbContext;

    public UserService(IHttpContextAccessor httpContextAccessor, EfDbContext dbContext)
    {
        _httpContextAccessor = httpContextAccessor;
        _dbContext = dbContext;
    }

    public async Task<List<UserGameResponse>> GetGames(CancellationToken cancellationToken)
    {
        var user = GetCurrentUser();
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
    public User? GetCurrentUser()
    {
       var httpContext =  _httpContextAccessor.HttpContext;
       var userId = httpContext!.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
       var username = httpContext!.User.FindFirst(ClaimTypes.Name)?.Value;
       if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(username)) return null;
       var user = new User
       {
           Id = int.Parse(userId),
           Username = username
       };
       return user; 
    }


    public async Task<List<UserMatchResponse>> GetLiveMatches(CancellationToken cancellationToken)
    {
        var user = GetCurrentUser() ?? throw new Exception("User Not Found");
        var res = await _dbContext.Matches
            .Where(x => x.Status != "completed" && x.Players.Any(p => p.GameAccount.ConnectedGame.UserId == user.Id))
            .Select(x => new UserMatchResponse
            {
                Id = x.Id,
                RemPlayers = x.RemPlayers,
                Status = x.Status,
                Tournament = new Dtos.Tournament.TournamentResponse
                {
                    Id = x.Tournament.Id,
                    PrizePool = x.Tournament.PrizePool,
                    Name = x.Tournament.Name,
                    Ticket = x.Tournament.Ticket,
                },
            })
            .ToListAsync(cancellationToken);
        return res;
    }
}