using Esportify.Api.Entity;
using Esportify.Api.Repository;
using Esportify.Shared.Utils;

namespace Esportify.Api.Map;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this WebApplication app)
    {
        app.MapGet("/users", async (IUserRepository userRepository) =>
        {
            var users = await userRepository.GetAllAsync();
            return Results.Ok(users);
        });

        app.MapGet("/users/{id}", async (int id, IUserRepository userRepository) =>
        {
            var user = await userRepository.GetByIdAsync(id);
            return user != null ? Results.Ok(user) : Results.NotFound();
        });

        app.MapPost("/users", async (UserEntity user, IUserRepository userRepository) =>
        {
            await userRepository.AddAsync(user);
            return Results.Created($"/users/{user.Id}", user);
        });

        app.MapPut("/users/{id}", async (int id, UserEntity user, IUserRepository userRepository) =>
        {
            if (id != user.Id)
            {
                return Results.BadRequest();
            }
            await userRepository.UpdateAsync(user);
            return Results.NoContent();
        });

        app.MapDelete("/users/{id}", async (int id, IUserRepository userRepository) =>
        {
            await userRepository.DeleteAsync(id);
            return Results.NoContent();
        });
    }
}