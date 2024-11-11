using Esportify.Shared.Model;

namespace Esportify.Shared.Services;

public interface IRoleService
{
    public Task<List<RoleModel>> GetAllAsync();
    public Task<RoleModel> GetByIdAsync(int id);
    public Task<RoleModel> CreateAsync(RoleModel newRole);
    public Task UpdateAsync(int id, RoleModel updatedRole);
    public Task DeleteAsync(int id);
}