﻿using System.Text.Json.Serialization;

namespace Esportify.Shared.Model;

public class EventImageModel
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("eventId")] public int EventId { get; set; }
    [JsonPropertyName("image")] public string Image { get; set; }
}