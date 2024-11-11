﻿using System.Text;
using System.Text.Json;
using Esportify.Shared.Model;

namespace Esportify.Shared.Services;

public class EventUserService : IEventUserService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public EventUserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _baseUrl = "https://localhost:7102/eventUsers";
    }

    public async Task<List<EventUserModel>> GetAllAsync()
    {
        var response = await _httpClient.GetAsync(_baseUrl);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<EventUserModel>>(content);
    }

    public async Task<EventUserModel> GetByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}/{id}");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<EventUserModel>(content);
    }

    public async Task<EventUserModel> CreateAsync(EventUserModel newEventUser)
    {
        var jsonContent = new StringContent(JsonSerializer.Serialize(newEventUser), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(_baseUrl, jsonContent);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<EventUserModel>(content);
    }

    public async Task UpdateAsync(int id, EventUserModel updatedUser)
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