using Esportify.Shared.Model;
using Esportify.Shared.Services;
using Microsoft.AspNetCore.Components;

namespace Esportify.Client.Pages;

public class HomeBase : ComponentBase
{
    #region Statements

    [Inject] private HttpClient _httpClient { get; set; }
    [Inject] private NavigationManager _navigationManager { get; set; }
    [Inject] private UserService _userService { get; set; }
    [Inject] private EventService _eventService { get; set; }
    [Inject] private IAuthService _authService { get; set; }
    
    protected List<EventModel> Events { get; set; } = new();
    
    protected List<string> Images { get; set; } = new();
    
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            Events = await _eventService.GetAllAsync();
        
            Images.Add(await EncodeImageToBase64Async("img/emanuel-ekstrom-I45hdPF5Na0-unsplash.jpg"));
            Images.Add(await EncodeImageToBase64Async("img/stem-list-ryRU-cd1yas-unsplash.jpg"));
            Images.Add(await EncodeImageToBase64Async("img/vecteezy_professional-esports-logo-template-for-game-team-or-gaming_7994829-1.jpg"));
            
            StateHasChanged();
        }
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
    
    protected string GetFormattedDate(DateTime date)
    {
        var culture = new System.Globalization.CultureInfo("fr-FR");
        return date.ToString("dddd dd MMMM yyyy 'à' HH:mm", culture);
    }
    
    protected void NavigateToSingleEventPage(int id)
    {
        _navigationManager.NavigateTo($"/SingleEvent/{id}");
    }

    protected void NavigateToGlobalEventPage()
    {
        _navigationManager.NavigateTo("/GlobalEvent");
    }

    private async Task<string> EncodeImageToBase64Async(string relativeImagePath)
    {
        const string baseUri = "https://esportify-app.azurewebsites.net/";
        var imageUrl = new Uri(new Uri(baseUri), relativeImagePath);

        var imageBytes = await _httpClient.GetByteArrayAsync(imageUrl);
        var base64String = Convert.ToBase64String(imageBytes);

        return $"data:image/jpeg;base64,{base64String}";
    }

    #endregion
}