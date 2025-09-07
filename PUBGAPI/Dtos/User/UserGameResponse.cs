namespace PUBGAPI.Dtos.User;

public class UserGameResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public UserGameAccountResponse Account { get; set; }
    
}
public class UserGameAccountResponse
{
    public string AccountId { get; set; }
}