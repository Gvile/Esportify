using System.Text;
using System.Text.Json;
using Esportify.Shared.Model;

namespace Esportify.Shared.Services;

public class EventStatusService : IEventStatusService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public EventStatusService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _baseUrl = "https://localhost:7102/eventStatus";
    }

    public async Task<List<EventStatusModel>> GetAllAsync()
    {
        var response = await _httpClient.GetAsync(_baseUrl);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<EventStatusModel>>(content);
    }

    public async Task<EventStatusModel> GetByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}/{id}");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<EventStatusModel>(content);
    }

    public async Task<EventStatusModel> CreateAsync(EventStatusModel newEventStatus)
    {
        var jsonContent = new StringContent(JsonSerializer.Serialize(newEventStatus), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(_baseUrl, jsonContent);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<EventStatusModel>(content);
    }

    public async Task UpdateAsync(int id, EventStatusModel updatedEventStatus)
    {
        var jsonContent = new StringContent(JsonSerializer.Serialize(updatedEventStatus), Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync($"{_baseUrl}/{id}", jsonContent);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
        response.EnsureSuccessStatusCode();
    }
}