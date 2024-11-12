using System.Text;
using System.Text.Json;
using Blazored.LocalStorage;
using Esportify.Shared.Model;

namespace Esportify.Shared.Services;

public class EventService : IEventService
{
    private readonly ILocalStorageService _localStorage;
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public EventService(HttpClient httpClient, ILocalStorageService localStorage)
    {
        _httpClient = httpClient;
        _localStorage = localStorage;
        _baseUrl = "https://localhost:7102/events";
    }

    public async Task<List<EventModel>> GetAllAsync()
    {
        var response = await _httpClient.GetAsync(_baseUrl);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<EventModel>>(content);
    }

    public async Task<EventModel> GetByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}/{id}");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<EventModel>(content);
    }

    public async Task<EventModel> CreateAsync(EventModel newEvent)
    {
        newEvent.StartDate = newEvent.StartDate.ToUniversalTime();
        newEvent.EndDate = newEvent.EndDate.ToUniversalTime();
        
        var jsonContent = new StringContent(JsonSerializer.Serialize(newEvent), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(_baseUrl, jsonContent);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<EventModel>(content);
    }

    public async Task UpdateAsync(EventModel updatedEvent)
    {
        updatedEvent.StartDate = updatedEvent.StartDate.ToUniversalTime();
        updatedEvent.EndDate = updatedEvent.EndDate.ToUniversalTime();

        // Récupérer le token JWT depuis le LocalStorage ou la méthode appropriée
        var token = await _localStorage.GetItemAsync<string>("authToken");
    
        if (string.IsNullOrEmpty(token))
        {
            throw new UnauthorizedAccessException("User is not authenticated.");
        }

        var jsonContent = new StringContent(JsonSerializer.Serialize(updatedEvent), Encoding.UTF8, "application/json");

        // Création de la requête HTTP avec le token JWT dans l'en-tête Authorization
        var requestMessage = new HttpRequestMessage(HttpMethod.Put, $"{_baseUrl}/{updatedEvent.Id}")
        {
            Content = jsonContent
        };

        requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        // Envoyer la requête HTTP
        var response = await _httpClient.SendAsync(requestMessage);

        // Vérifier si la réponse est réussie, sinon lever une exception
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
        response.EnsureSuccessStatusCode();
    }
}