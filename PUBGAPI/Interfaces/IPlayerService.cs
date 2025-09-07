using PUBGAPI.Dtos.User;

namespace PUBGAPI.Interfaces;

public interface IPlayerService
{
    public  Task<List<UserMatchResponse>> GetLiveMatches(CancellationToken cancellationToken);
    public Task<List<UserGameResponse>> GetGames(CancellationToken cancellationToken);
}