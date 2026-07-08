using CartNest.Interfaces;
using CartNest.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CartNest.Areas.User.Controllers
{
    [Area("User")]
    public class SettingsController : Controller
       
    {
        private readonly IOrderService _orderService;

        public SettingsController (IOrderService orderService)
        {
            _orderService = orderService;
        }
        public IActionResult Settings()
        {
            return View();
        }
        public IActionResult ResetPassword()
        {
            return View();
        }
        public async Task<IActionResult> MyOrders()
        {
            int userId = int.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var orders = await _orderService.GetOrdersByUserIdAsync(userId);

            return View(orders);
        }
    }
}