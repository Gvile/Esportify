using Esportify.Api.Services;
using Esportify.Shared.Model;

namespace Esportify.Api.Map;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this WebApplication app)
    {
        app.MapPost("/login", async (LoginRequest loginRequest, AuthService authService) =>
        {
            var token = await authService.LoginAsync(loginRequest.Email, loginRequest.Password);
            return token != null ? Results.Ok(new { Token = token }) : Results.Unauthorized();
        });

        app.MapPost("/register", async (RegisterRequest registerRequest, AuthService authService) =>
        {
            Console.WriteLine("Coucou c l'appel à l'api");
            await authService.RegisterAsync(registerRequest.Email, registerRequest.Password, registerRequest.Pseudo);
            return Results.Ok(new { Message = "User registered successfully" });
        });
    }
    
    public class RegisterRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Pseudo { get; set; }
    }

}