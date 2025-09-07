using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace PUBGAPI.Data;

public class EfDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<TournamentQueue> TournamentQueues { get; set; }
    public DbSet<WorkerQueueProgress> WorkerQueueProgress { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<User> Users { get; set; }

    public DbSet<Game> Games { get; set; }

    public DbSet<Tournament> Tournaments { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}