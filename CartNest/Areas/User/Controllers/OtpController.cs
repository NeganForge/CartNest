using CartNest.Services;
using Microsoft.AspNetCore.Mvc;

namespace CartNest.Areas.User.Controllers
{
    [Area("User")]
    public class OtpController : Controller
    {
        private readonly IOtpService _otpService;

        public OtpController(IOtpService otpService)
        {
            _otpService = otpService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendOtp(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return BadRequest("Email is required.");
            }

            var result = await _otpService.SendOtpAsync(email);

            if (!result)
            {
                return BadRequest("Failed to send OTP.");
            }

            return Ok("OTP sent successfully.");
        }

        [HttpPost]
        public async Task<IActionResult> VerifyOtp(string email, string otp)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(otp))
            {
                return BadRequest("Email and OTP are required.");
            }

            var isValid = await _otpService.VerifyOtpAsync(email, otp);

            if (!isValid)
            {
                return BadRequest("Invalid or expired OTP.");
            }

            return Ok("OTP verified successfully.");
        }
    }
}