using System.ComponentModel.DataAnnotations;

namespace CartNest.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }

        // Foreign Key
        public int UserId { get; set; }

        // Order Information
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public decimal TotalAmount { get; set; }

        [MaxLength(50)]
        public string Status { get; set; } = "Pending";

        // Navigation Properties
        public User User { get; set; } = null!;

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}