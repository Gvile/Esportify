namespace Esportify.Api.Entity;

public class EventEntity
{
    public int Id { get; set; }
    public int EventStatusId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int MaxUser { get; set; }
    
    private DateTime _startDate;
    public DateTime StartDate
    {
        get => _startDate;
        set => _startDate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    private DateTime _endDate;
    public DateTime EndDate
    {
        get => _endDate;
        set => _endDate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }
    
    public int OwnerUserId { get; set; }
}