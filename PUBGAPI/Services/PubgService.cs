using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;
using PUBGAPI.Config;
using PUBGAPI.Dtos;
using PUBGAPI.Interfaces;

namespace PUBGAPI.Services;


public class PubgService : IPlayService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly PubgConfig _pubgConfig;



    public async Task<PubgMatchResponse?> GetMatch(string id)
    {
        var idInUrl = WebUtility.UrlEncode(id);

        var client = _httpClientFactory.CreateClient("PUBG");
        var response = await client.GetAsync($"shards/{_pubgConfig.Shard}/matches/{idInUrl}");
        var content = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true // Makes "data" map to "Data"
        };
        return JsonSerializer.Deserialize<PubgMatchResponse>(content, options);
    }
    
    private double CalculateGarbageScore(PubgParticipantStats stats)
    {
        // Base score for just being in the game. Surviving longer reduces garbage score.
        double survivalPenalty = (1 - (stats.TimeSurvived / 1800)) * 50; // 1800 sec = 30 min max match time

        // Penalty for doing no damage
        double damagePenalty = (stats.DamageDealt == 0) ? 25 : 0;

        // Penalty for getting zero kills
        double killPenalty = (stats.Kills == 0) ? 25 : 0;

        // Penalty for a bad death type (e.g., suicide, logout)
        double deathTypePenalty = stats.DeathType switch
        {
            "suicide" or "logout" => 15,
            "byplayer" => 0, // Killed by another player is normal
            "alive" => 0,    // Won the game!
            _ => 5
        };

        // Add all penalties together
        double garbageScore = survivalPenalty + damagePenalty + killPenalty + deathTypePenalty;

        // Ensure the score doesn't go below 0
        return Math.Round(Math.Max(0, garbageScore), 2);
    }
    public async Task<PlayerPerformance> GetPlayerPerformanceForTournament(string gameMode, string accountId, DateTime tournamentStartTime)
    {
        var performance = new PlayerPerformance();
        var player = await GetPlayerById(accountId);
        var matches = player.Data.Relationships.Matches.Data;
        foreach (var match in matches)
        {
            var pubgMatch = await GetMatch(match.Id);
            if (pubgMatch is null || pubgMatch.Data.Attributes.GameMode != gameMode || pubgMatch.Data.Attributes.CreatedAt < tournamentStartTime) continue;
            var x = pubgMatch.Included.FirstOrDefault(x => x.Type == "participant" &&
                                                           (x.Attributes.Stats!).PlayerId == accountId);
            if (x == null) continue;
            var stats = x.Attributes.Stats!;
            performance.Kills = stats.Kills;
            performance.DamageDealt = stats.DamageDealt;
            performance.WinPlace = stats.WinPlace;
            performance.TimeSurvived = stats.TimeSurvived;
            performance.DeathType = stats.DeathType;
            performance.Score = CalculateGarbageScore(stats);
            break;
        }
        return performance;
    }



    public PubgService(IHttpClientFactory httpClientFactory, PubgConfig pubgConfig)
    {
        _httpClientFactory = httpClientFactory;
        _pubgConfig = pubgConfig;
    }
    public async Task<PubgResponse<List<PlayerApi>>?> GetPlayerByName(string name)
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
        return JsonSerializer.Deserialize<PubgResponse<List<PlayerApi>>>(content, options);
    }

    public async Task<PubgResponse<PlayerApi>?> GetPlayerById(string id)
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
        return JsonSerializer.Deserialize<PubgResponse<PlayerApi>>(content, options);
    }
}