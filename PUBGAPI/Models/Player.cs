namespace PUBGAPI.Data;

public class Player : BaseEntity
{
    public int MatchId { get; set; }
    public Match Match { get; set; } = null!;

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public double Score { get; set; }
    
    // we can add an entity for player performance
}