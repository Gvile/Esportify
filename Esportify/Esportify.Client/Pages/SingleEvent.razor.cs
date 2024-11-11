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

    protected EventModel Event { get; private set; } = new();
    
    protected override async Task OnInitializedAsync()
    {
        Event = await _eventService.GetByIdAsync(Id);
    }
    
    #endregion
}