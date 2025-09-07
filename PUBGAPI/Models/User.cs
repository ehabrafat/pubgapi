namespace PUBGAPI.Data;

public class User : BaseEntity
{
    public string Username { get; set; }
    public string Password { get; set; }
    public List<ConnectedGame> ConnectedGames { get; set; } = new();
}