using Esportify.Shared.Services;
using Microsoft.AspNetCore.Components;

namespace Esportify.Client.Pages;

public class LoginBase : ComponentBase
{
    protected LoginModel loginModel = new LoginModel();
    protected string loginError;
    
    [Inject] private NavigationManager _navigationManager { get; set; }
    [Inject] private IAuthService _authService { get; set; }

    protected async Task HandleLogin()
    {
        loginError = null;
        var isLoginSuccessful = await _authService.LoginAsync(loginModel.Email, loginModel.Password);

        if (isLoginSuccessful)
        {
            _navigationManager.NavigateTo("/");
        }
        else
        {
            loginError = "Invalid email or password.";
        }
    }

    protected class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}