using CartNest.Models.Entities;

namespace CartNest.Repositories
{

    public interface IUserProductRepository
    {
        Task<List<Product>> SearchAsync(string keyword);

        Task<Product?> GetByIdAsync(int id);
    }
}
