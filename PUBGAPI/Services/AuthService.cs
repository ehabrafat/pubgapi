using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PUBGAPI.Config;
using PUBGAPI.Data;
using PUBGAPI.Dtos;
using PUBGAPI.Interfaces;

namespace PUBGAPI.Services;

public class AuthService : IAuthService
{
    private EfDbContext _dbContext;
    private JwtConfig _jwtConfig;

    public AuthService(EfDbContext dbContext, JwtConfig jwtConfig)
    {
        _dbContext = dbContext;
        _jwtConfig = jwtConfig;
    }

    public async Task<LoginResponse> Login(LoginDto dto, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Username == dto.Username, cancellationToken);
        if (user is null)
        {
            throw new Exception("Invalid credentials");
        }
        IPasswordHasher<User> passwordHasher = new PasswordHasher<User>();
        if (passwordHasher.VerifyHashedPassword(user, user.Password, dto.Password) !=
            PasswordVerificationResult.Success)
        {
            throw new Exception("Invalid credentials");
        }
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), // Alternative standard for user id
            new Claim(ClaimTypes.Name, user.Username) // Alternative standard for username
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.SecretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtConfig.ExpiresInMinutes),
            signingCredentials: creds
        );
        return new LoginResponse
        {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(token)
        };
    }
    public async Task Register(RegisterDto dto, CancellationToken token)
    {
        var userExists = await _dbContext.Users.AnyAsync(x => x.Username == dto.Username, token);
        if (userExists)
        {
            throw new Exception("Username already exists");
        }
        var user = new User { Username = dto.Username };
        IPasswordHasher<User> passwordHasher = new PasswordHasher<User>();
        user.Password = passwordHasher.HashPassword(user, dto.Password);
        _dbContext.Add(user);
        await _dbContext.SaveChangesAsync(token);
    }
}