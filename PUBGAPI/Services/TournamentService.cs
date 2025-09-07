using Microsoft.EntityFrameworkCore;
using PUBGAPI.Data;
using PUBGAPI.Dtos.GameMode;
using PUBGAPI.Dtos.Tournament;
using PUBGAPI.Interfaces;

namespace PUBGAPI.Services;

public class TournamentService : ITournamentService
{
    private readonly EfDbContext _dbContext;

    public TournamentService(EfDbContext dbContext)
    {
        _dbContext = dbContext;
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