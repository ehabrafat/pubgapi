using PUBGAPI.Dtos;

namespace PUBGAPI.Interfaces;

public interface IPlayService
{

    public Task<PlayerPerformance> GetPlayerPerformanceForTournament(string gameMode, string accountId);
    public  Task<PubgResponse<List<PlayerApi>>?> GetPlayerByName(string name);
    public  Task<PubgResponse<PlayerApi>?> GetPlayerById(string id);
}