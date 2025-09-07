using PUBGAPI.Dtos.Tournament;

namespace PUBGAPI.Dtos.Matches;
public class MatchResponse
{
    public int TournamentId { get; set; }

    public TournamentResponse Tournament { get; set; } = null!;

    public int RemPlayers { get; set; }

    public List<PlayerResponse> Players { get; set; } = new();

    public DateTime? EndedAt { get; set; }

    public string Status { get; set; } = "Pending";
}

public class PlayerResponse
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public int Score { get; set; }
}