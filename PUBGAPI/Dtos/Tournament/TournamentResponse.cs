using PUBGAPI.Dtos.GameMode;

namespace PUBGAPI.Dtos.Tournament;

public class TournamentResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public decimal PrizePool { get; set; }
    
    public double Ticket { get; set; }
    
    public int Players { get; set; }

    public GameModeResponse Mode { get; set; }
}