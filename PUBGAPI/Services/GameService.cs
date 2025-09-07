using Microsoft.EntityFrameworkCore;
using PUBGAPI.Data;
using PUBGAPI.Dtos;
using PUBGAPI.Dtos.Game;
using PUBGAPI.Interfaces;

namespace PUBGAPI.Services;

public class GameService : IGameService
{
    private readonly EfDbContext _dbContext;
    private readonly IUserService _userService;
    private readonly IServiceProvider _serviceProvider;
    public GameService(EfDbContext dbContext, IUserService userService, IServiceProvider serviceProvider)
    {
        _dbContext = dbContext;
        _userService = userService;
        _serviceProvider = serviceProvider;
    }

    public async Task<PlayerPerformance> GetPlayerPerformanceForTournament(
        int tournamentId, 
        string accountId, 
        CancellationToken cancellationToken)
    {
        var user = _userService.GetCurrentUser() ?? throw new Exception("User not found");
        var tournament =
            await _dbContext.Tournaments.Include(x => x.GameMode).ThenInclude(x => x.Game)
                .FirstOrDefaultAsync(x => x.Id == tournamentId, cancellationToken) ??
            throw new Exception("Tournament not found");
        var exists = await _dbContext.Set<GameAccount>()
            .AnyAsync(x => x.AccountId == accountId, cancellationToken);
        if(!exists)  throw new Exception("Account not found");
        var gameService = _serviceProvider.GetRequiredKeyedService<IPlayService>(tournament.GameMode.Game.Name);
        var res = await gameService.GetPlayerPerformanceForTournament(tournament.GameMode.Name,
            accountId);
        return res;
    }
    
    public async Task DisConnect(int gameId, CancellationToken cancellationToken)
    {
        var game = await _dbContext.Games.FirstOrDefaultAsync(x => x.Id == gameId, cancellationToken);
        if (game is null) throw new Exception("Game not found");
        var user = _userService.GetCurrentUser();
        if (user is null) throw new Exception("User not found");
        var gameConnection = await _dbContext.Set<ConnectedGame>()
            .FirstOrDefaultAsync(x => x.UserId == user.Id && x.GameId == gameId, cancellationToken);
        if (gameConnection is null) throw new Exception("You are not connected to this game");
        _dbContext.Remove(gameConnection);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
    public async Task Connect(int gameId, GameConnectRequest req, CancellationToken cancellationToken)
    {
        var game = await _dbContext.Games.FirstOrDefaultAsync(x => x.Id == gameId, cancellationToken);
        if (game is null) throw new Exception("Game not found");
        var user = _userService.GetCurrentUser();
        if (user is null) throw new Exception("User not found");
        var alreadyConnected = await _dbContext.Set<ConnectedGame>()
            .AnyAsync(x => x.UserId == user.Id && x.GameId == gameId, cancellationToken);
        if (alreadyConnected) throw new Exception("You have already connected before");
        var accountExists = await _dbContext.Set<GameAccount>()
            .AnyAsync(x => x.AccountId == req.AccountName, cancellationToken);
        if (accountExists) throw new Exception("Account has already been registered before");
        var gameService = _serviceProvider.GetRequiredKeyedService<IPlayService>(game.Name);
        var player = await gameService.GetPlayerByName(req.AccountName);
        if (player is null || player.Errors.Count > 0)
            throw new Exception(player != null ? player.Errors[0].Detail : "Invalid Account");
        var connectGame = new ConnectedGame
        {
            UserId = user.Id,
            GameId = gameId,
            Account = new GameAccount
            {
                AccountId = player.Data[0].Id
            }
        };
        _dbContext.Add(connectGame);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
    public async Task<List<GameResponse>> GetAll(CancellationToken cancellationToken)
    {
        var games = await _dbContext.Games.Select(x=>new GameResponse
        {
            Id = x.Id,
            Name = x.Name
        }).ToListAsync(cancellationToken);
        return games;
    }
    public async Task<GameResponse> GetById(int id, CancellationToken cancellationToken)
    {
        var game = await _dbContext.Games.Select(x=>new GameResponse
        {
            Id = x.Id,
            Name = x.Name
        }).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (game is null) throw new Exception("Game not found");
        return game;
    }
}