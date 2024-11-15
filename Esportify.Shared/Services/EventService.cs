﻿using System.Text;
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
        _baseUrl = "https://esportify-api.azurewebsites.net/events";
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
        
        var jsonContent = new StringContent(JsonSerializer.Serialize(updatedEvent), Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync($"{_baseUrl}/{updatedEvent.Id}", jsonContent);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
        response.EnsureSuccessStatusCode();
    }
}