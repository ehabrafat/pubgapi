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
    // Join Touranment
}