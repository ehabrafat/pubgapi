using Microsoft.AspNetCore.Mvc;
using PUBGAPI.Dtos;
using PUBGAPI.Interfaces;

namespace PUBGAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IResult> Login([FromForm] LoginDto dto, CancellationToken cancellationToken)
    {
        var res = await _authService.Login(dto, cancellationToken);
        return Results.Ok(res);
    }
    [HttpPost("register")]
    public async Task<IResult> Register([FromForm] RegisterDto dto, CancellationToken cancellationToken)
    {
        await _authService.Register(dto, cancellationToken);
        return Results.Ok(new {message = "Registered Successfully"});
    }
}