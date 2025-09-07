namespace PUBGAPI.Dtos.Matches;

public class MatchPlayerResponse
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string AccountId { get; set; }

    public PlayerPerformance Performance { get; set; }
}