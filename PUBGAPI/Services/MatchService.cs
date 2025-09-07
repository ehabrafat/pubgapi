using PUBGAPI.Data;
using PUBGAPI.Interfaces;

namespace PUBGAPI.Services;
public class MatchService : IMatchService
{
    private readonly EfDbContext _dbContext;
    public MatchService(EfDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // public async Task
}

