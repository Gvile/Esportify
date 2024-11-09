using Esportify.Api.Entity;

namespace Esportify.Api.Repository;

public interface IEventStatusRepository
{
    public Task<IEnumerable<EventStatusEntity>> GetAllAsync();
    public Task<EventStatusEntity> GetByIdAsync(int id);
    public Task AddAsync(EventStatusEntity eventStatus);
    public Task UpdateAsync(EventStatusEntity eventStatus);
    public Task DeleteAsync(int id);
}