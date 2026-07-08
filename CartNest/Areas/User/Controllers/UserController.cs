using CartNest.Core.DTOs;
using CartNest.DTOs;
using CartNest.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace CartNest.Areas.User.Controllers
{
    [Area("User")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDto dto)
        {
            var user = await _userService.LoginAsync(dto);

            if (user == null)
            {
                ViewBag.Error = "Invalid Email or Password";
                return View();
            }

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.Name),
        new Claim(ClaimTypes.Email, user.Email)
    };

            var identity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal);

            return RedirectToAction(nameof(Welcome));
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var success =
                await _userService.RegisterAsync(dto);

            if (!success)
                return View(dto);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Welcome()
        {
            ViewBag.IsAuthenticated = User.Identity?.IsAuthenticated;
            ViewBag.UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ViewBag.Name = User.Identity?.Name;
            ViewBag.Email = User.FindFirst(ClaimTypes.Email)?.Value;

            return View();
        }
    }
}