using PUBGAPI.Dtos.Tournament;

namespace PUBGAPI.Dtos.Matches;
public class MatchResponse
{
    public int TournamentId { get; set; }

    public TournamentResponse Tournament { get; set; } = null!;

    public int RemPlayers { get; set; }

    public List<MatchPlayerResponse> Players { get; set; } = new();

    public DateTime? EndedAt { get; set; }

    public string Status { get; set; } = "Pending";
}

