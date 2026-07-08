using CartNest.Models.Entities;

namespace CartNest.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrderAsync(Order order);

        Task AddOrderItemsAsync(List<OrderItem> orderItems);

        Task PlaceOrderAsync(int userId);
        Task<List<Order>> GetOrdersByUserIdAsync(int userId);
    }
}