using Esportify.Api.Entity;
using Esportify.Api.Repository;

namespace Esportify.Api.Map;

public static class EventImageEndpoints
{
    public static void MapEventImageEndpoints(this WebApplication app)
    {
        app.MapGet("/eventImages", async (IEventImageRepository eventImageRepository) =>
        {
            var eventImages = await eventImageRepository.GetAllAsync();
            return Results.Ok(eventImages);
        });

        app.MapGet("/eventImages/{id}", async (int id, IEventImageRepository eventImageRepository) =>
        {
            var eventImage = await eventImageRepository.GetByIdAsync(id);
            return eventImage != null ? Results.Ok(eventImage) : Results.NotFound();
        });

        app.MapPost("/eventImages", async (EventImageEntity eventImage, IEventImageRepository eventImageRepository) =>
        {
            await eventImageRepository.AddAsync(eventImage);
            return Results.Created($"/eventImages/{eventImage.Id}", eventImage);
        });

        app.MapPut("/eventImages/{id}", async (int id, EventImageEntity eventImage, IEventImageRepository eventImageRepository) =>
        {
            if (id != eventImage.Id)
            {
                return Results.BadRequest();
            }
            await eventImageRepository.UpdateAsync(eventImage);
            return Results.NoContent();
        });

        app.MapDelete("/eventImages/{id}", async (int id, IEventImageRepository eventImageRepository) =>
        {
            await eventImageRepository.DeleteAsync(id);
            return Results.NoContent();
        });
    }
}