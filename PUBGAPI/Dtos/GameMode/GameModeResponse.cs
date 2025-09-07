using PUBGAPI.Dtos.Game;

namespace PUBGAPI.Dtos.GameMode;

public class GameModeResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public GameResponse Game { get; set; }
}