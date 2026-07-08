using CartNest.Core.DTOs;
using CartNest.Repositories;

namespace CartNest.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(
            IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<bool> LoginAsync(
            AdminDto model)
        {
            return await _adminRepository
                .LoginAsync(model);
        }
    }
}