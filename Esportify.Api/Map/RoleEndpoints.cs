using Esportify.Api.Entity;
using Esportify.Api.Repository;

namespace Esportify.Api.Map;

public static class RoleEndpoints
{
    public static void MapRoleEndpoints(this WebApplication app)
    {
        app.MapGet("/roles", async (IRoleRepository roleRepository) =>
        {
            var roles = await roleRepository.GetAllAsync();
            return Results.Ok(roles);
        });

        app.MapGet("/roles/{id}", async (int id, IRoleRepository roleRepository) =>
        {
            var role = await roleRepository.GetByIdAsync(id);
            return role != null ? Results.Ok(role) : Results.NotFound();
        });

        app.MapPost("/roles", async (RoleEntity role, IRoleRepository roleRepository) =>
        {
            await roleRepository.AddAsync(role);
            return Results.Created($"/roles/{role.Id}", role);
        });

        app.MapPut("/roles/{id}", async (int id, RoleEntity role, IRoleRepository roleRepository) =>
        {
            if (id != role.Id)
            {
                return Results.BadRequest();
            }
            await roleRepository.UpdateAsync(role);
            return Results.NoContent();
        });

        app.MapDelete("/roles/{id}", async (int id, IRoleRepository roleRepository) =>
        {
            await roleRepository.DeleteAsync(id);
            return Results.NoContent();
        });
    }
}