using Esportify.Api.Entity;

namespace Esportify.Api.Repository;

public interface IEventImageRepository
{
    public Task<IEnumerable<EventImageEntity>> GetAllAsync();
    public Task<EventImageEntity> GetByIdAsync(int id);
    public Task AddAsync(EventImageEntity eventImage);
    public Task UpdateAsync(EventImageEntity eventImage);
    public Task DeleteAsync(int id);
}