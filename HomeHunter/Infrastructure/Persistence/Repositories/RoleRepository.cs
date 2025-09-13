using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class RoleRepository (AppDbContext appDbContext) : IRoleRepository
{
    public async Task DeleteUserRoleAsync(Role userRole)
    {
        appDbContext.Remove(userRole);
        await appDbContext.SaveChangesAsync();
    }

    public async Task<long> InsertUserRoleAsync(Role userRole)
    {
        await appDbContext.AddAsync(userRole);
        await appDbContext.SaveChangesAsync();
        return userRole.RoleId;
    }

    public async Task<ICollection<Role>> SelectAllRolesAsync()
    {
        return await appDbContext.UserRoles.ToListAsync();
    }

    public Task<ICollection<User>> SelectAllUsersByRoleNameAsync(string roleName)
    {
        throw new NotImplementedException();
    }

    public async Task<long> SelectRoleIdByNameAsync(string roleName)
    {
        var role = await appDbContext.UserRoles.FirstOrDefaultAsync(x => x.Name == roleName);
        if (role is null)
        {
            throw new Exception();
        }
        return role.RoleId;
    }

    public async Task<Role> SelectUserRoleByRoleNameAsync(string userRoleName)
    {
        var rolse = await appDbContext.UserRoles
            .FirstOrDefaultAsync(r => r.Name == userRoleName);
        return rolse ?? throw new Exception($"Role with name '{userRoleName}' not found."); 

    }

    public Task UpdateUserRoleAsync(Role userRole)
    {
        throw new NotImplementedException();
    }
}
