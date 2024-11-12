using Esportify.Api.App;
using Esportify.Api.Entity;
using Microsoft.EntityFrameworkCore;

namespace Esportify.Api.Repository;

public class EventRepository : IEventRepository
{
    private readonly ApplicationDbContext _context;

    public EventRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<EventEntity>> GetAllAsync()
    {
        return await _context.Event.ToListAsync();
    }

    public async Task<EventEntity> GetByIdAsync(int id)
    {
        return await _context.Event.FindAsync(id);
    }

    public async Task AddAsync(EventEntity evt)
    {
        evt.StartDate = DateTime.SpecifyKind(evt.StartDate, DateTimeKind.Utc);
        evt.EndDate = DateTime.SpecifyKind(evt.EndDate, DateTimeKind.Utc);
        
        await _context.Event.AddAsync(evt);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(EventEntity evt)
    {
        evt.StartDate = DateTime.SpecifyKind(evt.StartDate, DateTimeKind.Utc);
        evt.EndDate = DateTime.SpecifyKind(evt.EndDate, DateTimeKind.Utc);
        
        _context.Event.Update(evt);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var evt = await _context.Event.FindAsync(id);
        if (evt != null)
        {
            _context.Event.Remove(evt);
            await _context.SaveChangesAsync();
        }
    }
}