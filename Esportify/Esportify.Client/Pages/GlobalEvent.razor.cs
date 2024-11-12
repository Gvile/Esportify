using Esportify.Shared.Model;
using Esportify.Shared.Services;
using Microsoft.AspNetCore.Components;

namespace Esportify.Client.Pages;

public class GlobalEventBase : ComponentBase
{
    #region Statements

    [Inject] private NavigationManager _navigationManager { get; set; }
    [Inject] private EventService _eventService { get; set; }
    [Inject] private UserService _userService { get; set; }
    [Inject] private EventUserService _eventUserService { get; set; }
    
    private UserModel _user;
    
    protected List<EventModel> Events { get; set; } = new();
    protected List<EventUserModel> EventUsers { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        Events = await _eventService.GetAllAsync();
        
        foreach (var evt in Events)
        {
            var user = await _userService.GetByIdAsync(evt.OwnerUserId);
            evt.OwnerUserPseudo = user.Pseudo;
        }
        
        EventUsers = await _eventUserService.GetAllAsync();

        _user = await _userService.GetByIdAsync(1);
    }

    #endregion

    #region Methods

    protected bool IsLiveEvent(EventModel evt)
    {
        var dateNow = DateTime.Now;

        if (evt.StartDate < dateNow)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected async Task OnSubscription(EventModel evt)
    {
        var eventUsers = await _eventUserService.GetAllAsync();

        var isExist = false;
        foreach (var eventUser in eventUsers)
        {
            if (eventUser.EventId == evt.Id && eventUser.UserId == _user.Id)
            {
                isExist = true;
                break;
            }
        }

        if (!isExist)
        {
            var eventUser = new EventUserModel(evt.Id, _user.Id);
            EventUsers.Add(await _eventUserService.CreateAsync(eventUser));
            StateHasChanged();
        }
    }

    protected bool IsSubscribed(int evtId)
    {
        var eventUser = EventUsers.FirstOrDefault(e => e.EventId == evtId && e.UserId == _user.Id);
        return eventUser != null;
    }
    
    protected void NavigateToSingleEventPage(int id)
    {
        _navigationManager.NavigateTo($"/SingleEvent/{id}");
    }
    
    protected string GetFormattedDate(DateTime date)
    {
        var culture = new System.Globalization.CultureInfo("fr-FR");
        return date.ToString("dddd dd MMMM yyyy 'à' HH:mm", culture);
    }

    #endregion
}