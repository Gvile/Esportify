using Esportify.Shared.Model;

namespace Esportify.Shared.Services;

public interface IEventImageService
{
    public Task<List<EventImageModel>> GetAllAsync();
    public Task<EventImageModel> GetByIdAsync(int id);
    public Task<EventImageModel> CreateAsync(EventImageModel newEventImage);
    public Task UpdateAsync(int id, EventImageModel updatedEventImage);
    public Task DeleteAsync(int id);
}