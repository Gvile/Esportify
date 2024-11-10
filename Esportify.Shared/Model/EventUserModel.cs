using System.Text.Json.Serialization;

namespace Esportify.Shared.Model;

public class EventUserModel
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("userID")] public int UserId { get; set; }
}