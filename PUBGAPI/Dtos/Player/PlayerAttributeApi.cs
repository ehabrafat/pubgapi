using System.Text.Json.Serialization;

namespace PUBGAPI.Dtos;

public class PlayerAttributeApi
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("stats")]
    public object Stats { get; set; } // Could be null or specific stats object

    public string ClanId { get; set; }

}