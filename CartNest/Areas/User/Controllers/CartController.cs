using CartNest.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CartNest.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId)
        {
            int userId = int.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            await _cartService.AddToCartAsync(userId, productId);

            return Json(new
            {
                success = true,
                message = "Product added to cart."
            });
        }
        [HttpGet]
        public async Task<IActionResult> GetCartCount()
        {
            int userId = int.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            int count = await _cartService.GetCartCountAsync(userId);

            return Json(new
            {
                count = count
            });
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            int userId = int.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var cartItems = await _cartService.GetCartItemsAsync(userId);

            return View(cartItems);
        }
        [HttpPost]
        public async Task<IActionResult> IncreaseQuantity(int cartId)
        {
            await _cartService.IncreaseQuantityAsync(cartId);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DecreaseQuantity(int cartId)
        {
            await _cartService.DecreaseQuantityAsync(cartId);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> RemoveItem(int cartId)
        {
            await _cartService.RemoveCartItemAsync(cartId);
            return Ok();
        }
    }
}