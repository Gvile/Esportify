using System.Text.Json.Serialization;

namespace Esportify.Shared.Model;

public class EventModel : ICloneable
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("eventStatusId")] public int EventStatusId { get; set; }
    [JsonPropertyName("title")] public string Title { get; set; }
    [JsonPropertyName("description")] public string Description { get; set; }
    [JsonPropertyName("maxUser")] public int MaxUser { get; set; }
    
    private DateTime _startDate;
    [JsonPropertyName("startDate")] public DateTime StartDate
    {
        get => _startDate;
        set => _startDate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    private DateTime _endDate;
    [JsonPropertyName("endDate")] public DateTime EndDate
    {
        get => _endDate;
        set => _endDate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }
    
    [JsonPropertyName("ownerUserId")] public int OwnerUserId { get; set; }
    
    public string OwnerUserPseudo { get; set; }
    
    public object Clone()
    {
        return new EventModel
        {
            Id = Id,
            EventStatusId = EventStatusId,
            Title = Title,
            Description = Description,
            MaxUser = MaxUser,
            StartDate = StartDate,
            EndDate = EndDate,
            OwnerUserId = OwnerUserId,
            OwnerUserPseudo = OwnerUserPseudo
        };
    }
}