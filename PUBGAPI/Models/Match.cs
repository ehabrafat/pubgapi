namespace PUBGAPI.Data;

public class Match : BaseEntity
{
    public int TournamentId { get; set; }
    
    public Tournament Tournament { get; set; } = null!;
    
    public int RemPlayers { get; set; }
    
    public List<Player> Players { get; set; } = new();

    public string Status { get; set; } = "Pending"; // pending, live, completed
}