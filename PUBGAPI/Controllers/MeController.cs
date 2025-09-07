using Microsoft.AspNetCore.Mvc;
using PUBGAPI.Interfaces;

namespace PUBGAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MeController : ControllerBase
{
    private readonly IUserService _userService;

    public MeController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("Games")]
    public async Task<IResult> GetGames(CancellationToken cancellationToken)
    {
        var res = await _userService.GetGames(cancellationToken);
        return Results.Ok(res);
    }

    [HttpGet("LiveMatches")]
    public async Task<IResult> GetLiveMatches(CancellationToken cancellationToken)
    {
        var res = await _userService.GetLiveMatches(cancellationToken);
        return Results.Ok(res);
    }
}