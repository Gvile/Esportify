namespace Esportify.Shared.Services;

public interface IAuthService
{
    public Task<bool> LoginAsync(string email, string password);
    public Task<bool> RegisterAsync(string email, string password, string pseudo);
    public Task<bool> IsLoggedInAsync();
    public Task LogoutAsync();
}