using Microsoft.AspNetCore.Mvc;
using PUBGAPI.Interfaces;

namespace PUBGAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TournamentsController : ControllerBase
{
    private readonly ITournamentService _tournamentService;

    public TournamentsController(ITournamentService tournamentService)
    {
        _tournamentService = tournamentService;
    }

    [HttpPost("{id:int}/join")]
    public async Task<IResult> Join(int id, CancellationToken cancellationToken)
    {
        await _tournamentService.Join(id, cancellationToken);
        return Results.Ok(new {message = "Joined Successfully"});
    }
}