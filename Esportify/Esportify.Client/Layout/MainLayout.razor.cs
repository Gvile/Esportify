using Microsoft.AspNetCore.Components;

namespace Esportify.Client.Layout;

public class MainLayoutBase : LayoutComponentBase
{
    #region Statements

    [Inject] private NavigationManager _navigationManager { get; set; }

    #endregion

    #region Methods

    protected void NavigateToHome()
    {
        _navigationManager.NavigateTo("/");
    }
    
    protected void NavigateToGlobalEvent()
    {
        _navigationManager.NavigateTo("/GlobalEvent");
    }

    #endregion
}