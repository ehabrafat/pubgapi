using System.Text.Json.Serialization;

namespace PUBGAPI.Dtos;

public class PubgResponse<T>
{
    [JsonPropertyName("data")]
    public T Data { get; set; }

    [JsonPropertyName("errors")] 
    public List<Error> Errors { get; set; } = new();
}