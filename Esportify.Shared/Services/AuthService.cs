using System.Text;
using System.Text.Json;
using Blazored.LocalStorage;
using Esportify.Shared.Model;
using Esportify.Shared.Utils;

namespace Esportify.Shared.Services;

public class AuthService : IAuthService
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;
    private readonly string _baseUrl;

    public AuthService(HttpClient httpClient, ILocalStorageService localStorage)
    {
        _httpClient = httpClient;
        _localStorage = localStorage;
        _baseUrl = "https://esportify-api.azurewebsites.net/login";
    }

    public async Task<bool> LoginAsync(string email, string password)
    {
        var loginData = new LoginRequest(email, password);
        var jsonContent = new StringContent(JsonSerializer.Serialize(loginData), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(_baseUrl, jsonContent);
        
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<TokenModel>(content);

            if (result != null && !string.IsNullOrEmpty(result.Token))
            {
                await _localStorage.SetItemAsync("authToken", result.Token);
                await _localStorage.SetItemAsync("authTokenExpiry", DateTime.UtcNow.AddHours(24));

                return true;
            }
        }

        return false; // Échec de l'authentification
    }

    public async Task<bool> RegisterAsync(string email, string password, string pseudo)
    {
        var registerData = new { Email = email, Password = password, Pseudo = pseudo };
        var json = JsonSerializer.Serialize(registerData);
        Console.WriteLine("Json envoyé: " + json);
        var jsonContent = new StringContent(JsonSerializer.Serialize(registerData), Encoding.UTF8, "application/json");
        //var response = await _httpClient.PostAsync($"{_baseUrl}/register", jsonContent);
        var response = await _httpClient.PostAsync("https://esportify-api.azurewebsites.net/register", jsonContent);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> IsLoggedInAsync()
    {
        // Vérifie si un token valide est présent
        var expiryDate = await _localStorage.GetItemAsync<DateTime?>("authTokenExpiry");
        return expiryDate.HasValue && expiryDate.Value > DateTime.UtcNow;
    }

    public async Task LogoutAsync()
    {
        // Supprime le token et sa date d’expiration de LocalStorage
        await _localStorage.RemoveItemAsync("authToken");
        await _localStorage.RemoveItemAsync("authTokenExpiry");
    }

    private class LoginResponse
    {
        public string Token { get; set; }
    }
}