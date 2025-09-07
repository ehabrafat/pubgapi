namespace PUBGAPI.Data;

public class Game : BaseEntity
{
    public string  Name { get; set; }
    public List<ConnectedGame> ConnectedGames { get; set; } = new();

    public List<GameMode> Modes { get; set; } = new();
}