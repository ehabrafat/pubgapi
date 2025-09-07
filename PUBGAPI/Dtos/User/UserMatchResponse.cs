using PUBGAPI.Dtos.Tournament;

namespace PUBGAPI.Dtos.User;
public class UserMatchResponse
{
    public int Id { get; set; }
    public int RemPlayers { get; set; }
    public string Status { get; set; }
    public TournamentResponse Tournament { get; set; }
    public List<MatchPlayerResponse> Players { get; set; } = new();
}

public class MatchPlayerResponse
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public double Score { get; set; }
}