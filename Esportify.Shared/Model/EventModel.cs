using System.Text.Json.Serialization;

namespace Esportify.Shared.Model;

[Serializable]
public class EventModel
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("eventStatusId")] public int EventStatusId { get; set; }
    [JsonPropertyName("title")] public string Title { get; set; }
    [JsonPropertyName("description")] public string Description { get; set; }
    [JsonPropertyName("maxUser")] public int MaxUser { get; set; }
    [JsonPropertyName("startDate")] public DateTime StartDate { get; set; }
    [JsonPropertyName("endDate")] public DateTime EndDate { get; set; }
    [JsonPropertyName("ownerUserId")] public int OwnerUserId { get; set; }
}