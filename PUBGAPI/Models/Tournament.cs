using Microsoft.EntityFrameworkCore;

namespace PUBGAPI.Data;

public class Tournament : BaseEntity
{
    public string? Name { get; set; }
    
    [Precision(18, 2)]
    public decimal PrizePool { get; set; }
    
    [Precision(18, 2)]
    public double Ticket { get; set; }
    public int Players { get; set; }
    public int DurationInMin { get; set; }
    public int GameModeId { get; set; }
    public GameMode GameMode { get; set; } = null!;
}