using CartNest.Interfaces;
using CartNest.Models.Entities;
using CartNest.Repositories;
using CartNest.Repositories.Interfaces;

namespace CartNest.Services
{
    public class UserProductService : IUserProductService
    {
        private readonly IUserProductRepository _userProductRepository;

        public UserProductService(
            IUserProductRepository userProductRepository)
        {
            _userProductRepository = userProductRepository;
        }

        public async Task<List<Product>> SearchAsync(string keyword)
        {
            return await _userProductRepository
                .SearchAsync(keyword);
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _userProductRepository
                .GetByIdAsync(id);
        }
    }
}