using CartNest.Data;
using CartNest.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CartNest.Repositories
{
    public class UserProductRepository : IUserProductRepository
    {
        private readonly ApplicationDbContext _context;
        public UserProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> SearchAsync(string keyword)
        {
            return await _context.Products
                .Where(p => p.Name.Contains(keyword))
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}