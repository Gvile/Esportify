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
    [Inject] private EventUserService _eventUserService { get; set; }

    protected EventModel Event { get; private set; } = new();
    protected List<EventUserModel> EventUsers { get; set; } = new();
    
    private UserModel _user;
    
    protected override async Task OnInitializedAsync()
    {
        Event = await _eventService.GetByIdAsync(Id);
        
        var user = await _userService.GetByIdAsync(Event.OwnerUserId);
        Event.OwnerUserPseudo = user.Pseudo;
        
        EventUsers = await _eventUserService.GetAllAsync();
        
        _user = await _userService.GetByIdAsync(1);
    }
    
    #endregion

    #region Methods
    
    protected async Task OnSubscription()
    {
        var eventUsers = await _eventUserService.GetAllAsync();

        var isExist = false;
        foreach (var eventUser in eventUsers)
        {
            if (eventUser.EventId == Event.Id && eventUser.UserId == _user.Id)
            {
                isExist = true;
                break;
            }
        }

        if (!isExist)
        {
            var eventUser = new EventUserModel(Event.Id, _user.Id);
            EventUsers.Add(await _eventUserService.CreateAsync(eventUser));
            StateHasChanged();
        }
    }
    
    protected bool IsSubscribed()
    {
        var eventUser = EventUsers.FirstOrDefault(e => e.EventId == Event.Id && e.UserId == _user.Id);
        return eventUser != null;
    }

    protected string GetFormattedDate(DateTime date)
    {
        var culture = new System.Globalization.CultureInfo("fr-FR");
        return date.ToString("dddd dd MMMM yyyy 'à' HH:mm", culture);
    }

    #endregion
}