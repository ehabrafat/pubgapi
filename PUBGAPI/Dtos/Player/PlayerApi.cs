using System.Text.Json.Serialization;

namespace PUBGAPI.Dtos;

public class PlayerApi
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    
    [JsonPropertyName("attributes")]
    public PlayerAttributeApi Attributes { get; set; }

    public RelationshipApi Relationships { get; set; }

}