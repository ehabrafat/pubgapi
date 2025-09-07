using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;
using PUBGAPI.Config;
using PUBGAPI.Dtos;
using PUBGAPI.Interfaces;

namespace PUBGAPI.Services;

public class PubgService : IPlayerService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly PubgConfig _pubgConfig;
    

    public PubgService(IHttpClientFactory httpClientFactory, PubgConfig pubgConfig)
    {
        _httpClientFactory = httpClientFactory;
        _pubgConfig = pubgConfig;
    }
    public async Task<PubgResponse<List<Player>>?> GetPlayerByName(string name)
    {
        // 1. VALIDATE INPUT
        if (string.IsNullOrWhiteSpace(name))
        {    
            throw new ArgumentException("Player name cannot be empty.");
        }

        // 2. CHECK LENGTH - PUBG names have max length (e.g., 16 chars)
        if (name.Length > 16)
        {
            throw new ArgumentException("Player name is too long.");
        }

        // 3. SANITIZE - Prevent URL injection & weird characters
        // Allow only alphanumeric characters, underscores, and hyphens
        var sanitizedName = Regex.Replace(name, @"[^a-zA-Z0-9_\-]", "");
        if (string.IsNullOrEmpty(sanitizedName))
        {
            throw new ArgumentException("Invalid player name format.");
        }
        var encodedName = WebUtility.UrlEncode(name);
        var client = _httpClientFactory.CreateClient("PUBG");
        var response = await client.GetAsync($"shards/{_pubgConfig.Shard}/players?filter[playerNames]={encodedName}");
        var content = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true // Makes "data" map to "Data"
        };
        return JsonSerializer.Deserialize<PubgResponse<List<Player>>>(content, options);
    }

    public async Task<PubgResponse<Player>?> GetPlayerById(string id)
    {
        // 1. VALIDATE INPUT
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException("Player name cannot be empty.");
        }

        var encodedName = WebUtility.UrlEncode(id);
        var client = _httpClientFactory.CreateClient("PUBG");
        var response = await client.GetAsync($"shards/{_pubgConfig.Shard}/players/{id}");
        var content = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true // Makes "data" map to "Data"
        };
        return JsonSerializer.Deserialize<PubgResponse<Player>>(content, options);
    }
}