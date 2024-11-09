using Esportify.Api.App;
using Esportify.Api.Entity;
using Microsoft.EntityFrameworkCore;

namespace Esportify.Api.Repository;

public class EventStatusRepository : IEventStatusRepository
{
    private readonly ApplicationDbContext _context;

    public EventStatusRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<EventStatusEntity>> GetAllAsync()
    {
        return await _context.EventStatus.ToListAsync();
    }

    public async Task<EventStatusEntity> GetByIdAsync(int id)
    {
        return await _context.EventStatus.FindAsync(id);
    }

    public async Task AddAsync(EventStatusEntity eventStatus)
    {
        await _context.EventStatus.AddAsync(eventStatus);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(EventStatusEntity eventStatus)
    {
        _context.EventStatus.Update(eventStatus);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var eventStatus = await _context.EventStatus.FindAsync(id);
        if (eventStatus != null)
        {
            _context.EventStatus.Remove(eventStatus);
            await _context.SaveChangesAsync();
        }
    }
}