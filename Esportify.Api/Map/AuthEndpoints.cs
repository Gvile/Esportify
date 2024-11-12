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

        app.MapPost("/register", async (string email, string password, AuthService authService) =>
        {
            await authService.RegisterAsync(email, password);
            return Results.Ok(new { Message = "User registered successfully" });
        });
    }
}