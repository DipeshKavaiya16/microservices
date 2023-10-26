using ShoppingApp.Models;

namespace ShoppingApp.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDtoModel>> GetProducts();
        Task<IEnumerable<ProductDtoModel>> GetProductsByCategory(string categoryId);
        Task<ProductDtoModel> GetProduct(string id);
        Task<ProductDtoModel> CreateProduct(ProductDtoModel model);
    }
}
