using PUBGAPI.Data;
using PUBGAPI.Dtos.User;

namespace PUBGAPI.Interfaces;

public interface IUserService
{

    public Task<List<UserGameResponse>> GetGames(CancellationToken cancellationToken);
    public User? GetCurrentUser();
}