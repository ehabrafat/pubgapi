using PUBGAPI.Dtos.Tournament;

namespace PUBGAPI.Interfaces;

public interface ITournamentService
{
    public Task<List<TournamentResponse>> GetAll(int gameId, CancellationToken cancellationToken);

}