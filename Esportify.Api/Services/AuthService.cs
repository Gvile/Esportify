using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Esportify.Api.App;
using Esportify.Api.Entity;
using Esportify.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Esportify.Api.Services;

public class AuthService
{
    private readonly ApplicationDbContext _context;
    private readonly IConfiguration _config;

    public AuthService(ApplicationDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    public async Task<string> LoginAsync(string email, string password)
    {
        var user = await _context.User.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null || !PasswordHasherUtils.VerifyPassword(password, user.Password))
        {
            return null; // Email ou mot de passe incorrect
        }
        return GenerateJwtToken(user);
    }

    public async Task RegisterAsync(string email, string password)
    {
        string passwordHash = PasswordHasherUtils.HashPassword(password);

        var newUser = new UserEntity
        {
            Email = email,
            Password = passwordHash
        };

        _context.User.Add(newUser);
        await _context.SaveChangesAsync();
    }

    private string GenerateJwtToken(UserEntity user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
