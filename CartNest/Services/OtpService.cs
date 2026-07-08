using CartNest.Models;
using CartNest.Repositories.Interfaces;

namespace CartNest.Services
{
    public class OtpService : IOtpService
    {
        private readonly IOtpRepository _otpRepository;
        private readonly IEmailService _emailService;

        public OtpService(
            IOtpRepository otpRepository,
            IEmailService emailService)
        {
            _otpRepository = otpRepository;
            _emailService = emailService;
        }

        public async Task<bool> SendOtpAsync(string email)
        {
            var oldOtps = await _otpRepository.GetActiveOtpsByEmailAsync(email);

            foreach (var otp in oldOtps)
            {
                otp.IsUsed = true;
                await _otpRepository.UpdateOtpAsync(otp);
            }

            string code = new Random().Next(100000, 999999).ToString();

            var otpEntry = new Otp
            {
                Email = email,
                Code = code,
                ExpiryTime = DateTime.UtcNow.AddMinutes(5),
                CreatedAt = DateTime.UtcNow,
                IsUsed = false
            };

            await _otpRepository.SaveOtpAsync(otpEntry);

            await _emailService.SendEmailAsync(
    email,
    "CartNest - Email Verification",
    $@"
    <div style='font-family:Arial,Helvetica,sans-serif;max-width:600px;margin:auto;border:1px solid #e5e7eb;border-radius:10px;overflow:hidden;'>

        <div style='background:#2563eb;padding:20px;text-align:center;color:white;'>
            <h1 style='margin:0;'>CartNest</h1>
            <p style='margin:5px 0 0;'>Secure Email Verification</p>
        </div>

        <div style='padding:30px;'>

            <h2 style='color:#111827;'>Verify Your Email Address</h2>

            <p style='font-size:16px;color:#374151;'>
                Thank you for choosing <strong>CartNest</strong>.
                Please use the One-Time Password (OTP) below to verify your email address.
            </p>

            <div style='margin:30px 0;text-align:center;'>

                <span style='display:inline-block;
                             background:#f3f4f6;
                             color:#2563eb;
                             font-size:32px;
                             font-weight:bold;
                             letter-spacing:8px;
                             padding:15px 35px;
                             border-radius:8px;
                             border:2px dashed #2563eb;'>

                    {code}

                </span>

            </div>

            <p style='font-size:15px;color:#374151;'>
                ⏳ This OTP is valid for <strong>5 minutes</strong>.
            </p>

            <p style='font-size:15px;color:#374151;'>
                If you did not request this verification, you can safely ignore this email.
            </p>

            <hr style='margin:30px 0;border:none;border-top:1px solid #e5e7eb;' />

            <p style='font-size:13px;color:#6b7280;text-align:center;'>
                This is an automated email from <strong>CartNest</strong>. Please do not reply to this message.
            </p>

        </div>

    </div>"
);

            return true;
        }

        public async Task<bool> VerifyOtpAsync(string email, string otp)
        {
            var otpEntry = await _otpRepository.GetLatestOtpAsync(email, otp);

            if (otpEntry == null)
                return false;

            if (otpEntry.ExpiryTime < DateTime.UtcNow)
                return false;

            otpEntry.IsUsed = true;
            await _otpRepository.UpdateOtpAsync(otpEntry);

            return true;
        }
    }
}