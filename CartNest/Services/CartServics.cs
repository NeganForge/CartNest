using CartNest.Interfaces;
using CartNest.Models;

namespace CartNest.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task AddToCartAsync(int userId, int productId)
        {
            await _cartRepository.AddToCartAsync(userId, productId);
        }
        public async Task<int> GetCartCountAsync(int userId)
        {
            return await _cartRepository.GetCartCountAsync(userId);
        }
        public async Task<List<Cart>> GetCartItemsAsync(int userId)
        {
            return await _cartRepository.GetCartItemsAsync(userId);
        }
        public async Task IncreaseQuantityAsync(int cartId)
        {
            await _cartRepository.IncreaseQuantityAsync(cartId);
        }
        public async Task DecreaseQuantityAsync(int cartId)
        {
            await _cartRepository.DecreaseQuantityAsync(cartId);
        }
        public async Task RemoveCartItemAsync(int cartId)
        {
            await _cartRepository.RemoveCartItemAsync(cartId);
        }
    }
}