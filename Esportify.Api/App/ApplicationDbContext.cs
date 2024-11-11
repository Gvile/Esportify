using Esportify.Api.Entity;
using Microsoft.EntityFrameworkCore;

namespace Esportify.Api.App;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<UserEntity> User { get; set; }
    public DbSet<EventEntity> Event { get; set; }
    public DbSet<EventStatusEntity> EventStatus { get; set; }
    public DbSet<EventImageEntity> EventImage { get; set; }
    public DbSet<EventUserEntity> EventUser { get; set; }
    public DbSet<RoleEntity> Role { get; set; }
}