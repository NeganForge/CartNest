using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace CartNest.Models.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public string? ImageUrl { get; set; }

        public int CategoryId { get; set; }

        [ValidateNever]
        public Category Category { get; set; } = null!;
    }
}