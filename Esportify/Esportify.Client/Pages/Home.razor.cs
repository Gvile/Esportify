using Esportify.Shared.Services;
using Microsoft.AspNetCore.Components;

namespace Esportify.Client.Pages;

public class HomeBase : ComponentBase
{
    [Inject] private IEventService _eventService { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        var events = await _eventService.GetAllEventsAsync();

        Console.WriteLine(events.Count);
        foreach (var evt in events)
        {
            Console.WriteLine(evt.Id);
            Console.WriteLine(evt.Description);
            Console.WriteLine(evt.Title);
            Console.WriteLine(evt.StartDate);
        }
    }
}