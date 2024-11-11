﻿using Esportify.Shared.Model;
using Esportify.Shared.Services;
using Microsoft.AspNetCore.Components;

namespace Esportify.Client.Pages;

public class HomeBase : ComponentBase
{
    #region Statements

    [Inject] private EventService _eventService { get; set; }
    
    protected List<EventModel> Events { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        Events = await _eventService.GetAllAsync();
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

    #endregion
}