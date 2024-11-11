using System.Text.Json.Serialization;

namespace Esportify.Shared.Model;

public class EventStatusModel
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("name")] public string Name { get; set; }
}