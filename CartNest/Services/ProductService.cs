using CartNest.Models.Entities;
using CartNest.Repositories;

namespace CartNest.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Product product)
        {
            await _productRepository.AddAsync(product);
            await _productRepository.SaveAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            await _productRepository.UpdateAsync(product);
            await _productRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
            await _productRepository.SaveAsync();
        }
    }
}