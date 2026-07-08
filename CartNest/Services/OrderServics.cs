using CartNest.Interfaces;
using CartNest.Models.Entities;
using CartNest.Repositories.Interfaces;

namespace CartNest.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task CreateOrderAsync(Order order)
        {
            await _orderRepository.CreateOrderAsync(order);
        }

        public async Task AddOrderItemsAsync(List<OrderItem> orderItems)
        {
            await _orderRepository.AddOrderItemsAsync(orderItems);
        }
        public async Task PlaceOrderAsync(int userId)
        {
            await _orderRepository.PlaceOrderAsync(userId);
        }
        public async Task<List<Order>> GetOrdersByUserIdAsync(int userId)
        {
            return await _orderRepository.GetOrdersByUserIdAsync(userId);
        }

    }
}