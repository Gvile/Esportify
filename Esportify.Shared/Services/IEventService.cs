using Esportify.Shared.Model;

namespace Esportify.Shared.Services;

public interface IEventService
{
    public Task<List<EventModel>> GetAllEventsAsync();
    public Task<EventModel> GetEventByIdAsync(int id);
    public Task<EventModel> CreateEventAsync(EventModel newEvent);
    public Task UpdateEventAsync(int id, EventModel updatedEvent);
    public Task DeleteEventAsync(int id);
}