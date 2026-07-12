using CartNest.Models.Entities;

namespace CartNest.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task CreateOrderAsync(Order order);

        Task AddOrderItemsAsync(List<OrderItem> orderItems);

        Task PlaceOrderAsync(int userId);

        Task<List<Order>> GetOrdersByUserIdAsync(int userId);
        Task<Order?> GetOrderDetailsAsync(int orderId, int userId);
    }
}