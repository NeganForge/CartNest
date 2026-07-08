using System.ComponentModel.DataAnnotations;

namespace CartNest.Models.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }

        // Foreign Keys
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        // Order Item Information
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        // Navigation Properties
        public Order Order { get; set; } = null!;

        public Product Product { get; set; } = null!;
    }
}