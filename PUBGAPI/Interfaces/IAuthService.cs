using PUBGAPI.Dtos;

namespace PUBGAPI.Interfaces;

public interface IAuthService
{
    public Task Register(RegisterDto dto, CancellationToken token);
    public Task<LoginResponse> Login(LoginDto dto, CancellationToken token);

}