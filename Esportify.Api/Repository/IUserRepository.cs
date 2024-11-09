using Esportify.Api.Entity;

namespace Esportify.Api.Repository;

public interface IUserRepository
{
    public Task<IEnumerable<UserEntity>> GetAllAsync();
    public Task<UserEntity> GetByIdAsync(int id);
    public Task AddAsync(UserEntity user);
    public Task UpdateAsync(UserEntity user);
    public Task DeleteAsync(int id);
}