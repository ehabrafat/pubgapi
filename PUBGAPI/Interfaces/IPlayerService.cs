using PUBGAPI.Dtos;

namespace PUBGAPI.Interfaces;

public interface IPlayerService
{

    public  Task<PubgResponse<List<Player>>?> GetPlayerByName(string name);
    public  Task<PubgResponse<Player>?> GetPlayerById(string id);
}