using Esportify.Shared.Model;

namespace Esportify.Shared.Services;

public interface IUserService
{
    public Task<List<UserModel>> GetAllUsersAsync();
    public Task<UserModel> GetUserByIdAsync(int id);
    public Task<UserModel> CreateUserAsync(UserModel newUser);
    public Task UpdateUserAsync(int id, UserModel updatedUser);
    public Task DeleteUserAsync(int id);
}