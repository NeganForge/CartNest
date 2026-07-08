using CartNest.Models.Entities;

namespace CartNest.Models
{
    public class Cart
    {
        public int Id { get; set; }

        // Foreign Keys
        public int UserId { get; set; }
        public int ProductId { get; set; }

        // Cart Information
        public int Quantity { get; set; } = 1;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public User User { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}