using System.Text.Json.Serialization;

namespace PUBGAPI.Dtos;

public class Player
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    
    [JsonPropertyName("attributes")]
    public PlayerAttribute Attribute { get; set; }

    public Relationship Relationships { get; set; }

}