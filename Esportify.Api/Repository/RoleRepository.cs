using Esportify.Api.App;
using Esportify.Api.Entity;
using Microsoft.EntityFrameworkCore;

namespace Esportify.Api.Repository;

public class RoleRepository : IRoleRepository
{
    private readonly ApplicationDbContext _context;

    public RoleRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<RoleEntity>> GetAllAsync()
    {
        return await _context.Role.ToListAsync();
    }

    public async Task<RoleEntity> GetByIdAsync(int id)
    {
        return await _context.Role.FindAsync(id);
    }

    public async Task AddAsync(RoleEntity role)
    {
        await _context.Role.AddAsync(role);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(RoleEntity role)
    {
        _context.Role.Update(role);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var role = await _context.Role.FindAsync(id);
        if (role != null)
        {
            _context.Role.Remove(role);
            await _context.SaveChangesAsync();
        }
    }
}