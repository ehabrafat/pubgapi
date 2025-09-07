using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using PUBGAPI.Data;
using PUBGAPI.Dtos.Game;
using PUBGAPI.Dtos.GameMode;
using PUBGAPI.Dtos.Matches;
using PUBGAPI.Dtos.User;
using PUBGAPI.Interfaces;

namespace PUBGAPI.Services;

public class UserService : IUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly EfDbContext _dbContext;

    public UserService(IHttpContextAccessor httpContextAccessor, EfDbContext dbContext)
    {
        _httpContextAccessor = httpContextAccessor;
        _dbContext = dbContext;
    }

    public User? GetCurrentUser()
    {
       var httpContext =  _httpContextAccessor.HttpContext;
       var userId = httpContext!.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
       var username = httpContext!.User.FindFirst(ClaimTypes.Name)?.Value;
       if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(username)) return null;
       var user = new User
       {
           Id = int.Parse(userId),
           Username = username
       };
       return user; 
    }


}