namespace PUBGAPI.Config;

public class JwtConfig
{
    public string SecretKey { get; set; }

    public int ExpiresInMinutes { get; set; }
}