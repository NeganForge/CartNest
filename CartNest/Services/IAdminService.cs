using CartNest.Core.DTOs;

namespace CartNest.Services
{
    public interface IAdminService
    {
        Task<bool> LoginAsync(AdminDto model);
    }
}