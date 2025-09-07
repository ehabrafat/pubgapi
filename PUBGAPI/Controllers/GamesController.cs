using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PUBGAPI.Dtos.Game;
using PUBGAPI.Interfaces;

namespace PUBGAPI.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class GamesController : ControllerBase
{
    private readonly IGameService _gameService;
    private readonly ITournamentService _tournamentService;

    public GamesController(IGameService gameService, ITournamentService tournamentService)
    {
        _gameService = gameService;
        _tournamentService = tournamentService;
    }

    
    [HttpGet]
    public async Task<IResult> GetAll(CancellationToken cancellationToken)
    {
        var games = await _gameService.GetAll(cancellationToken);
        return Results.Ok(games);
    } 
    
    [HttpGet("{id:int}")]
    public async Task<IResult> GetById(int id, CancellationToken cancellationToken)
    {
        var game = await _gameService.GetById(id, cancellationToken);
        return Results.Ok(game);
    } 
    [HttpGet("{id:int}/tournaments")]
    public async Task<IResult> GetAllTournaments(int id, CancellationToken cancellationToken)
    {
        var res = await _tournamentService.GetAll(id, cancellationToken);
        return Results.Ok(res);
    } 
    [HttpPost("{id:int}/connect")]
    public async Task<IResult> Connect(int id, [FromForm] GameConnectRequest req, CancellationToken cancellationToken)
    {
        await _gameService.Connect(id, req, cancellationToken);
        return Results.Ok(new { message = "Connected Successfully" });
    } 
    [HttpDelete("{id:int}/DisConnect")]
    public async Task<IResult> DisConnect(int id, CancellationToken cancellationToken)
    {
        await _gameService.DisConnect(id, cancellationToken);
        return Results.Ok(new { message = "DisConnected Successfully" });
    } 
}