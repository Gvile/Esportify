using Esportify.Shared.Model;

namespace Esportify.Shared.Services;

public interface IEventStatusService
{
    public Task<List<EventStatusModel>> GetAllAsync();
    public Task<EventStatusModel> GetByIdAsync(int id);
    public Task<EventStatusModel> CreateAsync(EventStatusModel newEventStatus);
    public Task UpdateAsync(int id, EventStatusModel updatedEventStatus);
    public Task DeleteAsync(int id);
}