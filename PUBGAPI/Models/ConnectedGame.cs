namespace PUBGAPI.Data;

public class ConnectedGame : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public int GameId { get; set; }
    public Game Game { get; set; } = null!;
    public GameAccount Account { get; set; } = null!;
}