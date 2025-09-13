using Application.Interfaces;
using Domain.Entities;

namespace Infrastructure.Persistence.Repositories;

internal class UserRepository (AppDbContext appDbContext) : IUserRepository
{
    public Task DeleteUserById(long userId)
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<long> InsertUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User?> SelectByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<User?> SelectUserByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<User?> SelectUserByUserNameAsync(string userName)
    {
        throw new NotImplementedException();
    }

    public Task UpdateUserRoleAsync(long userId, long userRoleId)
    {
        throw new NotImplementedException();
    }
}
