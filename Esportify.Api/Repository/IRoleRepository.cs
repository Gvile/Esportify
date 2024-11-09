using Esportify.Api.Entity;

namespace Esportify.Api.Repository;

public interface IRoleRepository
{
    public Task<IEnumerable<RoleEntity>> GetAllAsync();
    public Task<RoleEntity> GetByIdAsync(int id);
    public Task AddAsync(RoleEntity role);
    public Task UpdateAsync(RoleEntity role);
    public Task DeleteAsync(int id);
}