using CartNest.Data;
using CartNest.Models;
using CartNest.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CartNest.Repositories
{
    public class OtpRepository : IOtpRepository
    {
        private readonly ApplicationDbContext _context;

        public OtpRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveOtpAsync(Otp otp)
        {
            await _context.Otps.AddAsync(otp);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Otp>> GetActiveOtpsByEmailAsync(string email)
        {
            return await _context.Otps
                .Where(x => x.Email == email && !x.IsUsed)
                .ToListAsync();
        }

        public async Task<Otp?> GetLatestOtpAsync(string email, string code)
        {
            return await _context.Otps
                .Where(x => x.Email == email &&
                            x.Code == code &&
                            !x.IsUsed)
                .OrderByDescending(x => x.CreatedAt)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateOtpAsync(Otp otp)
        {
            _context.Otps.Update(otp);
            await _context.SaveChangesAsync();
        }
    }
}