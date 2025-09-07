using PUBGAPI.Dtos.Tournament;

namespace PUBGAPI.Dtos.User;
public class UserMatchResponse
{
    public int Id { get; set; }
    public int RemPlayers { get; set; }
    public string Status { get; set; }
    public TournamentResponse Tournament { get; set; }
}

