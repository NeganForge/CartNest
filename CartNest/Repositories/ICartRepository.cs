using CartNest.Models;

namespace CartNest.Interfaces
{
    public interface ICartRepository
    {
        Task AddToCartAsync(int userId, int productId);
        Task<int> GetCartCountAsync(int userId);
        Task<List<Cart>> GetCartItemsAsync(int userId);
        Task IncreaseQuantityAsync(int cartId);

        Task DecreaseQuantityAsync(int cartId);

        Task RemoveCartItemAsync(int cartId);

    }
}