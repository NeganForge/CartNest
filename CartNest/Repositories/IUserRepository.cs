using CartNest.Models.Entities;

namespace CartNest.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);

        Task AddAsync(User user);
    }
}