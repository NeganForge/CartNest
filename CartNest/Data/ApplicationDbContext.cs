using BCrypt.Net;
using CartNest.Models;
using CartNest.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CartNest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext
            (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Otp> Otps { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Admin>().HasData(
            new Admin
            {
                Id = 1,
                UserName = "admin",
                Password = BCrypt.Net.BCrypt.HashPassword("admin123")
            }
        );
    }
}
}