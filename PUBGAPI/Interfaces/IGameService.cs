using PUBGAPI.Dtos.Game;

namespace PUBGAPI.Interfaces;

public interface IGameService
{
    public Task DisConnect(int gameId, CancellationToken cancellationToken);
    public Task Connect(int gameId, GameConnectRequest req, CancellationToken cancellationToken);
    public Task<GameResponse> GetById(int id, CancellationToken cancellationToken);
    public Task<List<GameResponse>> GetAll(CancellationToken cancellationToken);

}