using BCrypt.Net;
using CartNest.Core.DTOs;
using CartNest.Data;
using Microsoft.EntityFrameworkCore;

namespace CartNest.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationDbContext _context;

        public AdminRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> LoginAsync(AdminDto model)
        {
            var admin = await _context.Admins
                .FirstOrDefaultAsync(x =>
                   x.UserName == model.UserName);

            if (admin == null)
                return false;

            if (!BCrypt.Net.BCrypt.Verify(
                model.Password,
                admin.Password))
            {
                return false;
            }

            return true;
        }
    }
}