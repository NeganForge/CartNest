using CartNest.Models.Entities;

public interface IUserProductService
{
    Task<List<Product>> SearchAsync(string keyword);

    Task<Product?> GetByIdAsync(int id);
}