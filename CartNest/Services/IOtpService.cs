namespace CartNest.Services
{
    public interface IOtpService
    {
        Task<bool> SendOtpAsync(string email);

        Task<bool> VerifyOtpAsync(string email, string otp);
    }
}