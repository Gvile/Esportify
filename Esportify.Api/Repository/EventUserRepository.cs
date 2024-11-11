using Esportify.Api.App;
using Esportify.Api.Entity;
using Microsoft.EntityFrameworkCore;

namespace Esportify.Api.Repository;

public class EventUserRepository : IEventUserRepository
{
    private readonly ApplicationDbContext _context;

    public EventUserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<EventUserEntity>> GetAllAsync()
    {
        return await _context.EventUser.ToListAsync();
    }

    public async Task<EventUserEntity> GetByIdAsync(int id)
    {
        return await _context.EventUser.FindAsync(id);
    }

    public async Task AddAsync(EventUserEntity eventUser)
    {
        await _context.EventUser.AddAsync(eventUser);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(EventUserEntity eventUser)
    {
        _context.EventUser.Update(eventUser);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var eventUser = await _context.EventUser.FindAsync(id);
        if (eventUser != null)
        {
            _context.EventUser.Remove(eventUser);
            await _context.SaveChangesAsync();
        }
    }
}