using Esportify.Api.Entity;
using Esportify.Api.Repository;

namespace Esportify.Api.Map;

public static class EventEndpoints
{
    public static void MapEventEndpoints(this WebApplication app)
    {
        app.MapGet("/events", async (IEventRepository eventRepository) =>
        {
            var evts = await eventRepository.GetAllAsync();
            return Results.Ok(evts);
        });

        app.MapGet("/events/{id}", async (int id, IEventRepository eventRepository) =>
        {
            var evt = await eventRepository.GetByIdAsync(id);
            return evt != null ? Results.Ok(evt) : Results.NotFound();
        });

        app.MapPost("/events", async (EventEntity evt, IEventRepository eventRepository) =>
        {
            await eventRepository.AddAsync(evt);
            return Results.Created($"/events/{evt.Id}", evt);
        });

        app.MapPut("/events/{id}", async (int id, EventEntity evt, IEventRepository eventRepository) =>
        {
            if (id != evt.Id)
            {
                return Results.BadRequest();
            }
            await eventRepository.UpdateAsync(evt);
            return Results.NoContent();
        });

        app.MapDelete("/events/{id}", async (int id, IEventRepository eventRepository) =>
        {
            await eventRepository.DeleteAsync(id);
            return Results.NoContent();
        });
    }
}