using Esportify.Shared.Model;
using Esportify.Shared.Services;
using Microsoft.AspNetCore.Components;

namespace Esportify.Client.Pages;

public class SingleEventBase : ComponentBase
{
    #region Statements

    [Parameter] public int Id { get; set; }
    
    [Inject] private NavigationManager _navigationManager { get; set; }
    [Inject] private EventService _eventService { get; set; }
    [Inject] private UserService _userService { get; set; }

    protected EventModel Event { get; private set; } = new();
    
    protected override async Task OnInitializedAsync()
    {
        Event = await _eventService.GetByIdAsync(Id);
        
        var user = await _userService.GetByIdAsync(Event.OwnerUserId);
        Event.OwnerUserPseudo = user.Pseudo;
    }
    
    #endregion

    #region Methods

    protected string GetFormattedDate(DateTime date)
    {
        var culture = new System.Globalization.CultureInfo("fr-FR");
        return date.ToString("dddd dd MMMM yyyy 'à' HH:mm", culture);
    }

    #endregion
}