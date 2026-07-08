using CartNest.Data;
using CartNest.Models.Entities;
using CartNest.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CartNest.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateOrderAsync(Order order)
        {
            _context.Orders.Add(order);

            await _context.SaveChangesAsync();
        }

        public async Task AddOrderItemsAsync(List<OrderItem> orderItems)
        {
            _context.OrderItems.AddRange(orderItems);

            await _context.SaveChangesAsync();
        }
        public async Task PlaceOrderAsync(int userId)
        {
            var cartItems = await _context.Carts
                .Include(c => c.Product)
                .Where(c => c.UserId == userId)
                .ToListAsync();

            if (!cartItems.Any())
            {
                return;
            }
            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.Now,
                Status = "Pending",
                TotalAmount = 0
            };
            _context.Orders.Add(order);

            await _context.SaveChangesAsync();
            var orderItems = new List<OrderItem>();

            foreach (var cartItem in cartItems)
            {
                orderItems.Add(new OrderItem
                {
                    OrderId = order.Id,
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                    Price = cartItem.Product.Price
                });
            }
            _context.OrderItems.AddRange(orderItems);

            await _context.SaveChangesAsync();
            order.TotalAmount = cartItems.Sum(c => c.Product.Price * c.Quantity);

            await _context.SaveChangesAsync();
            _context.Carts.RemoveRange(cartItems);

            await _context.SaveChangesAsync();
        }
        public async Task<List<Order>> GetOrdersByUserIdAsync(int userId)
        {
            return await _context.Orders
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }
    }
}