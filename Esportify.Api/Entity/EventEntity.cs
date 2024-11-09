namespace Esportify.Api.Entity;

public class EventEntity
{
    public int Id { get; set; }
    public int EventStatusIs { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int MaxUser { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int OwnerUserId { get; set; }
}