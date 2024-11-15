using System.Text;
using System.Text.Json;
using Esportify.Shared.Model;

namespace Esportify.Shared.Services;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _baseUrl = "https://esportify-api.azurewebsites.net/users";
    }

    public async Task<List<UserModel>> GetAllAsync()
    {
        var response = await _httpClient.GetAsync(_baseUrl);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<UserModel>>(content);
    }

    public async Task<UserModel> GetByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}/{id}");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<UserModel>(content);
    }

    public async Task<UserModel> CreateAsync(UserModel newUser)
    {
        var jsonContent = new StringContent(JsonSerializer.Serialize(newUser), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(_baseUrl, jsonContent);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<UserModel>(content);
    }

    public async Task UpdateAsync(int id, UserModel updatedUser)
    {
        var jsonContent = new StringContent(JsonSerializer.Serialize(updatedUser), Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync($"{_baseUrl}/{id}", jsonContent);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
        response.EnsureSuccessStatusCode();
    }
}