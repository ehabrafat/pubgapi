namespace PUBGAPI.Data;

public class GameAccount : BaseEntity
{
    public string AccountId { get; set; }
    public bool Verified { get; set; }
    public int ConnectedGameId { get; set; }
    public ConnectedGame ConnectedGame { get; set; } = null!;
}   