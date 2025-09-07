
using Microsoft.EntityFrameworkCore;
using PUBGAPI.Data;
using PUBGAPI.Utils;

namespace PUBGAPI.BackgroundServices
{
    public class WorkerService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        public WorkerService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested) {
                try
                {
                    if (TournamentQueue.Queue.TryDequeue(out var player))
                    {

                        // get last mat in this tour, consider mat created in the last day
                           using (var scope = _serviceProvider.CreateScope())
                           {
                               var dbContext = scope.ServiceProvider.GetService<EfDbContext>();
                               if (dbContext is null) return;
                               var startDate = DateTime.UtcNow.AddDays(-1);
                               var match = await dbContext.Matches.Include(x=>x.Tournament)
                                   .Where(x => x.CreatedAt >= startDate
                                       && x.TournamentId == player.TournamentId && x.Status == "pending")
                                   .OrderByDescending(x => x.CreatedAt)
                                   .FirstOrDefaultAsync(stoppingToken);

                               if (match != null)
                               {
                                   match.RemPlayers -= 1;
                                   if (match.RemPlayers == 0)
                                   {
                                       match.Status = "live";
                                       match.EndedAt = DateTime.UtcNow.AddMinutes(match.Tournament.DurationInMin);

                                   }
                                match.Players.Add(new Player { GameAccountId = player.GameAccountId });
                               }
                               else
                               {
                                   var tournament = await dbContext.Tournaments.FirstOrDefaultAsync(x => x.Id == player.TournamentId, stoppingToken);
                                   if (tournament != null)
                                   {
                                       var newMatch = new Match
                                       {
                                           TournamentId = tournament.Id,
                                           RemPlayers = tournament.Players - 1,
                                           Status = tournament.Players == 1 ? "live" : "pending",
                                           EndedAt = tournament.Players == 1 ?
                                           DateTime.UtcNow.AddMinutes(tournament.DurationInMin) : null,
                                           Players = new List<Player>
                                           {
                                               new Player{GameAccountId = player.GameAccountId }
                                           }
                                       };
                                       dbContext.Add(newMatch);
                                   }
                               }
                               await dbContext.SaveChangesAsync(stoppingToken);
                           }
                    }
                } catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    await Task.Delay(5000, stoppingToken);
                }
            }
        }
    }
}
