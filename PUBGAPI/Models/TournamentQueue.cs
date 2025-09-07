namespace PUBGAPI.Data;

public class TournamentQueue : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public int TournamentId { get; set; }
    public Tournament Tournament { get; set; } = null!;
}