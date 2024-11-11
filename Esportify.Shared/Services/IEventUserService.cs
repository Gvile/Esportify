using Esportify.Shared.Model;

namespace Esportify.Shared.Services;

public interface IEventUserService
{
    public Task<List<EventUserModel>> GetAllAsync();
    public Task<EventUserModel> GetByIdAsync(int id);
    public Task<EventUserModel> CreateAsync(EventUserModel newEventUser);
    public Task UpdateAsync(int id, EventUserModel updatedEventUser);
    public Task DeleteAsync(int id);
}