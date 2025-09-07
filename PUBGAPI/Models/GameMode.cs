namespace PUBGAPI.Data;

public class GameMode : BaseEntity
{
    public string Name { get; set; }

    public string? Description { get; set; }
    public int GameId { get; set; }
    public Game Game { get; set; } = null!;
}