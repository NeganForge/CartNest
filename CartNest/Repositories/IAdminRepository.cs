using CartNest.Core.DTOs;

namespace CartNest.Repositories
{
    public interface IAdminRepository
    {
        Task<bool> LoginAsync(AdminDto model);
    }
}