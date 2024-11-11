using Esportify.Shared.Model;

namespace Esportify.Shared.Services;

public interface IUserService
{
    public Task<List<UserModel>> GetAllAsync();
    public Task<UserModel> GetByIdAsync(int id);
    public Task<UserModel> CreateAsync(UserModel newUser);
    public Task UpdateAsync(int id, UserModel updatedUser);
    public Task DeleteAsync(int id);
}