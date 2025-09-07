using System;
using System.Collections.Generic;

public class PubgMatchResponse
{
    public PubgData Data { get; set; }
    public List<PubgIncluded> Included { get; set; }
    public PubgLinks Links { get; set; }
    public PubgMeta Meta { get; set; }
}

public class PubgData
{
    public string Type { get; set; }
    public string Id { get; set; }
    public PubgAttributes Attributes { get; set; }
    public PubgRelationships Relationships { get; set; }
    public PubgLinks Links { get; set; }
}

public class PubgAttributes
{
    public DateTime? CreatedAt { get; set; }
    public int Duration { get; set; }
    public string TitleId { get; set; }
    public string MapName { get; set; }
    public string SeasonState { get; set; }
    public string GameMode { get; set; }
    public object Tags { get; set; }
    public bool IsCustomMatch { get; set; }
    public string MatchType { get; set; }
    public PubgParticipantStats? Stats { get; set; }
    public string? Won { get; set; }
    public string? ShardId { get; set; }
}

public class PubgParticipantStats
{
    public int DBNOs { get; set; }
    public int Assists { get; set; }
    public int Boosts { get; set; }
    public double DamageDealt { get; set; }
    public string DeathType { get; set; }
    public int HeadshotKills { get; set; }
    public int Heals { get; set; }
    public int KillPlace { get; set; }
    public int KillStreaks { get; set; }
    public int Kills { get; set; }
    public double LongestKill { get; set; }
    public string Name { get; set; }
    public string PlayerId { get; set; }
    public int Revives { get; set; }
    public double RideDistance { get; set; }
    public int RoadKills { get; set; }
    public double SwimDistance { get; set; }
    public int TeamKills { get; set; }
    public double TimeSurvived { get; set; }
    public int VehicleDestroys { get; set; }
    public double WalkDistance { get; set; }
    public int WeaponsAcquired { get; set; }
    public int WinPlace { get; set; }
}

public class PubgRosterStats
{
    public int Rank { get; set; }
    public int TeamId { get; set; }
}

public class PubgRelationships
{
    public PubgRosterData Rosters { get; set; }
    public PubgAssetData Assets { get; set; }
    
    // For roster relationships
    public PubgTeamData Team { get; set; }
    public PubgParticipantData Participants { get; set; }
}

public class PubgRosterData
{
    public List<PubgDataObject> Data { get; set; }
}

public class PubgAssetData
{
    public List<PubgDataObject> Data { get; set; }
}

public class PubgTeamData
{
    public object Data { get; set; }
}

public class PubgParticipantData
{
    public List<PubgDataObject> Data { get; set; }
}

public class PubgDataObject
{
    public string Type { get; set; }
    public string Id { get; set; }
}

public class PubgIncluded
{
    public string Type { get; set; }
    public string Id { get; set; }
    public PubgAttributes Attributes { get; set; }
    public PubgRelationships Relationships { get; set; }
}


public class PubgLinks
{
    public string Self { get; set; }
    public string Schema { get; set; }
}

public class PubgMeta
{
    // Meta properties would go here if needed
}