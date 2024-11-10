using System.Text;
using System.Text.Json;
using Esportify.Shared.Model;

namespace Esportify.Shared.Services;

public class RoleService : IRoleService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public RoleService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _baseUrl = "https://localhost:7102/roles";
    }

    public async Task<List<RoleModel>> GetAllAsync()
    {
        var response = await _httpClient.GetAsync(_baseUrl);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<RoleModel>>(content);
    }

    public async Task<RoleModel> GetByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}/{id}");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<RoleModel>(content);
    }

    public async Task<RoleModel> CreateAsync(RoleModel newRole)
    {
        var jsonContent = new StringContent(JsonSerializer.Serialize(newRole), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(_baseUrl, jsonContent);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<RoleModel>(content);
    }

    public async Task UpdateAsync(int id, RoleModel updatedRole)
    {
        var jsonContent = new StringContent(JsonSerializer.Serialize(updatedRole), Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync($"{_baseUrl}/{id}", jsonContent);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
        response.EnsureSuccessStatusCode();
    }
}