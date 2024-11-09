using Esportify.Api.Entity;

namespace Esportify.Api.Repository;

public interface IEventRepository
{
    public Task<IEnumerable<EventEntity>> GetAllAsync();
    public Task<EventEntity> GetByIdAsync(int id);
    public Task AddAsync(EventEntity evt);
    public Task UpdateAsync(EventEntity evt);
    public Task DeleteAsync(int id);
}