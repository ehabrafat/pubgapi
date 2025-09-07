using PUBGAPI.Data;

namespace PUBGAPI.Dtos;

public class RelationshipApi
{
    // assets
    public DataWrapper<MatchShortApi> Matches { get; set; }
}