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
        //Console.WriteLine($"password: {password}, hashed: {PasswordHasherUtils.HashPassword(password)} || user.Password {user.Password}");
        
        //if (user == null || !PasswordHasherUtils.VerifyPassword(password, user.Password)) 
        if (user == null || user.Password != password)
        {
            return null; // Email ou mot de passe incorrect
        }
        return GenerateJwtToken(user);
    }
    
    public async Task RegisterAsync(string email, string password, string pseudo)
    {
        string passwordHash = PasswordHasherUtils.HashPassword(password);
        Console.WriteLine(passwordHash);
        var newUser = new UserEntity
        {
            Email = email,
            Password = passwordHash,
            Pseudo = pseudo,
            RoleId = 1
        };
        Console.WriteLine("Utilisateur à ajouter: " + newUser);
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
