using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PUBGAPI.Interfaces;

namespace PUBGAPI.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class MeController : ControllerBase
{
    private readonly IPlayerService _playerService;

    public MeController(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    [HttpGet("Games")]
    public async Task<IResult> GetGames(CancellationToken cancellationToken)
    {
        var res = await _playerService.GetGames(cancellationToken);
        return Results.Ok(res);
    }

    [HttpGet("LiveMatches")]
    public async Task<IResult> GetLiveMatches(CancellationToken cancellationToken)
    {
        var res = await _playerService.GetLiveMatches(cancellationToken);
        return Results.Ok(res);
    }
}