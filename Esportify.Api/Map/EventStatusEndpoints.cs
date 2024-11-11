using Esportify.Api.Entity;
using Esportify.Api.Repository;

namespace Esportify.Api.Map;

public static class EventStatusEndpoints
{
    public static void MapEventStatusEndpoints(this WebApplication app)
    {
        app.MapGet("/eventStatus", async (IEventStatusRepository eventStatusRepository) =>
        {
            var eventStatus = await eventStatusRepository.GetAllAsync();
            return Results.Ok(eventStatus);
        });

        app.MapGet("/eventStatus/{id}", async (int id, IEventStatusRepository eventStatusRepository) =>
        {
            var eventStatus = await eventStatusRepository.GetByIdAsync(id);
            return eventStatus != null ? Results.Ok(eventStatus) : Results.NotFound();
        });

        app.MapPost("/eventStatus", async (EventStatusEntity eventStatus, IEventStatusRepository eventStatusRepository) =>
        {
            await eventStatusRepository.AddAsync(eventStatus);
            return Results.Created($"/eventStatus/{eventStatus.Id}", eventStatus);
        });

        app.MapPut("/eventStatus/{id}", async (int id, EventStatusEntity eventStatus, IEventStatusRepository eventStatusRepository) =>
        {
            if (id != eventStatus.Id)
            {
                return Results.BadRequest();
            }
            await eventStatusRepository.UpdateAsync(eventStatus);
            return Results.NoContent();
        });

        app.MapDelete("/eventStatus/{id}", async (int id, IEventStatusRepository eventStatusRepository) =>
        {
            await eventStatusRepository.DeleteAsync(id);
            return Results.NoContent();
        });
    }
}