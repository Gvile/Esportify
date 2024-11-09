using Esportify.Api.App;
using Esportify.Api.Entity;
using Microsoft.EntityFrameworkCore;

namespace Esportify.Api.Repository;

public class EventImageRepository : IEventImageRepository
{
    private readonly ApplicationDbContext _context;

    public EventImageRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<EventImageEntity>> GetAllAsync()
    {
        return await _context.EventImage.ToListAsync();
    }

    public async Task<EventImageEntity> GetByIdAsync(int id)
    {
        return await _context.EventImage.FindAsync(id);
    }

    public async Task AddAsync(EventImageEntity eventImage)
    {
        await _context.EventImage.AddAsync(eventImage);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(EventImageEntity eventImage)
    {
        _context.EventImage.Update(eventImage);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var eventImage = await _context.EventImage.FindAsync(id);
        if (eventImage != null)
        {
            _context.EventImage.Remove(eventImage);
            await _context.SaveChangesAsync();
        }
    }
}