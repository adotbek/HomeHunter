using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IOwnerRepository
{
    Task<long> AddOwnerAsync(Owner owner);
    Task UpdateOwnerAsync(Owner owner);
    Task DeleteOwnerAsync(long id);
    Task<Owner?> GetByIdAsync(long id);
    Task<ICollection<Owner>> GetAllAsync();
    Task<Owner?> GetByUserNameAsync(string userName);
    Task<Owner?> GetByEmailAsync(string email);
    Task<ICollection<Home>> GetHomesByOwnerIdAsync(long ownerId);
}
