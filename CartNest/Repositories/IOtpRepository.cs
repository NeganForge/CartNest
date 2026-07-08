using CartNest.Models;

namespace CartNest.Repositories.Interfaces
{
    public interface IOtpRepository
    {
        Task SaveOtpAsync(Otp otp);

        Task<List<Otp>> GetActiveOtpsByEmailAsync(string email);

        Task<Otp?> GetLatestOtpAsync(string email, string code);

        Task UpdateOtpAsync(Otp otp);
    }
}