using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class OwnerRepository(AppDbContext _context) : IOwnerRepository
{
    public async Task<long> AddOwnerAsync(Owner owner)
    {
        await _context.Owners.AddAsync(owner);
        await _context.SaveChangesAsync();
        return owner.Id;
    }

    public async Task UpdateOwnerAsync(Owner owner)
    {
        _context.Owners.Update(owner);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteOwnerAsync(long id)
    {
        var owner = await _context.Owners.FindAsync(id);
        if (owner != null)
        {
            _context.Owners.Remove(owner);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Owner?> GetByIdAsync(long id)
    {
        return await _context.Owners
            .Include(o => o.Homes)
            .Include(o => o.RefreshTokens)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<ICollection<Owner>> GetAllAsync()
    {
        return await _context.Owners
            .Include(o => o.Homes)
            .Include(o => o.Role)
            .ToListAsync();
    }

    public async Task<Owner?> GetByUserNameAsync(string userName)
    {
        return await _context.Owners
            .FirstOrDefaultAsync(o => o.UserName == userName);
    }

    public async Task<Owner?> GetByEmailAsync(string email)
    {
        return await _context.Owners
            .FirstOrDefaultAsync(o => o.Email == email);
    }

    public async Task<ICollection<Home>> GetHomesByOwnerIdAsync(long ownerId)
    {
        return await _context.Homes
            .Where(h => h.OwnerId == ownerId)
            .ToListAsync();
    }
}
