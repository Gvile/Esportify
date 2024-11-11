using Esportify.Api.Entity;
using Esportify.Api.Repository;

namespace Esportify.Api.Map;

public static class EventUserEndpoints
{
    public static void MapEventUserEndpoints(this WebApplication app)
    {
        app.MapGet("/eventUsers", async (IEventUserRepository eventUserRepository) =>
        {
            var eventUsers = await eventUserRepository.GetAllAsync();
            return Results.Ok(eventUsers);
        });

        app.MapGet("/eventUsers/{id}", async (int id, IEventUserRepository eventUserRepository) =>
        {
            var eventUser = await eventUserRepository.GetByIdAsync(id);
            return eventUser != null ? Results.Ok(eventUser) : Results.NotFound();
        });

        app.MapPost("/eventUsers", async (EventUserEntity eventUser, IEventUserRepository eventUserRepository) =>
        {
            await eventUserRepository.AddAsync(eventUser);
            return Results.Created($"/eventUsers/{eventUser.Id}", eventUser);
        });

        app.MapPut("/eventUsers/{id}", async (int id, EventUserEntity eventUser, IEventUserRepository eventUserRepository) =>
        {
            if (id != eventUser.Id)
            {
                return Results.BadRequest();
            }
            await eventUserRepository.UpdateAsync(eventUser);
            return Results.NoContent();
        });

        app.MapDelete("/eventUsers/{id}", async (int id, IEventUserRepository eventUserRepository) =>
        {
            await eventUserRepository.DeleteAsync(id);
            return Results.NoContent();
        });
    }
}