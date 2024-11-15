using Esportify.Api.App;
using Esportify.Api.Entity;
using Esportify.Shared.Utils;
using Microsoft.EntityFrameworkCore;

namespace Esportify.Api.Repository;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserEntity>> GetAllAsync()
    {
        return await _context.User.ToListAsync();
    }

    public async Task<UserEntity> GetByIdAsync(int id)
    {
        return await _context.User.FindAsync(id);
    }

    public async Task AddAsync(UserEntity user)
    {
        string passwordHash = PasswordHasherUtils.HashPassword(user.Password);
        Console.WriteLine(passwordHash);
        var newUser = new UserEntity
        {
            Email = user.Email,
            Password = passwordHash,
            Pseudo = user.Pseudo,
            RoleId = 1,
        };
        Console.WriteLine(newUser.ToString());
        await _context.User.AddAsync(newUser);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(UserEntity user)
    {
        _context.User.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var user = await _context.User.FindAsync(id);
        if (user != null)
        {
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}