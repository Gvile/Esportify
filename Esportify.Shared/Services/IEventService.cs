using Esportify.Shared.Model;

namespace Esportify.Shared.Services;

public interface IEventService
{
    public Task<List<EventModel>> GetAllAsync();
    public Task<EventModel> GetByIdAsync(int id);
    public Task<EventModel> CreateAsync(EventModel newEvent);
    public Task UpdateAsync(EventModel updatedEvent);
    public Task DeleteAsync(int id);
}