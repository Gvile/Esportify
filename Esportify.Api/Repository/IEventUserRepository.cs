using Esportify.Api.Entity;

namespace Esportify.Api.Repository;

public interface IEventUserRepository
{
    public Task<IEnumerable<EventUserEntity>> GetAllAsync();
    public Task<EventUserEntity> GetByIdAsync(int id);
    public Task AddAsync(EventUserEntity eventUser);
    public Task UpdateAsync(EventUserEntity eventUser);
    public Task DeleteAsync(int id);
}