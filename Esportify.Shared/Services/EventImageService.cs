using System.Text;
using System.Text.Json;
using Esportify.Shared.Model;

namespace Esportify.Shared.Services;

public class EventImageService : IEventImageService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public EventImageService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _baseUrl = "https://esportify-api.azurewebsites.net/eventImages";
    }

    public async Task<List<EventImageModel>> GetAllAsync()
    {
        var response = await _httpClient.GetAsync(_baseUrl);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<EventImageModel>>(content);
    }

    public async Task<EventImageModel> GetByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}/{id}");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<EventImageModel>(content);
    }

    public async Task<EventImageModel> CreateAsync(EventImageModel newEventImage)
    {
        var jsonContent = new StringContent(JsonSerializer.Serialize(newEventImage), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(_baseUrl, jsonContent);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<EventImageModel>(content);
    }

    public async Task UpdateAsync(int id, EventImageModel updatedEventImage)
    {
        var jsonContent = new StringContent(JsonSerializer.Serialize(updatedEventImage), Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync($"{_baseUrl}/{id}", jsonContent);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
        response.EnsureSuccessStatusCode();
    }
}