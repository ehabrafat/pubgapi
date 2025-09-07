using PUBGAPI.Data;
using PUBGAPI.Dtos.User;

namespace PUBGAPI.Interfaces;

public interface IUserService
{
    public User? GetCurrentUser();
}