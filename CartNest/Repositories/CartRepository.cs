using CartNest.Data;
using CartNest.Interfaces;
using CartNest.Models;
using Microsoft.EntityFrameworkCore;

namespace CartNest.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;

        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddToCartAsync(int userId, int productId)
        {
            var cartItem = await _context.Carts
                .FirstOrDefaultAsync(c =>
                    c.UserId == userId &&
                    c.ProductId == productId);

            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else
            {
                cartItem = new Cart
                {
                    UserId = userId,
                    ProductId = productId,
                    Quantity = 1
                };

                await _context.Carts.AddAsync(cartItem);
            }

            await _context.SaveChangesAsync();
        }
        public async Task<int> GetCartCountAsync(int userId)
        {
            return await _context.Carts
                .Where(c => c.UserId == userId)
                .SumAsync(c => c.Quantity);
        }
        public async Task<List<Cart>> GetCartItemsAsync(int userId)
        {
            return await _context.Carts
                .Include(c => c.Product)
                .Where(c => c.UserId == userId)
                .ToListAsync();
        }
        public async Task IncreaseQuantityAsync(int cartId)
        {
            var cart = await _context.Carts.FindAsync(cartId);

            if (cart == null)
                return;

            cart.Quantity++;

            await _context.SaveChangesAsync();
        }
        public async Task DecreaseQuantityAsync(int cartId)
        {
            var cart = await _context.Carts.FindAsync(cartId);

            if (cart == null)
                return;

            if (cart.Quantity > 1)
            {
                cart.Quantity--;
            }
            else
            {
                _context.Carts.Remove(cart);
            }

            await _context.SaveChangesAsync();
        }
        public async Task RemoveCartItemAsync(int cartId)
        {
            var cart = await _context.Carts.FindAsync(cartId);

            if (cart == null)
                return;

            _context.Carts.Remove(cart);

            await _context.SaveChangesAsync();
        }
    }
}