using Catalog.API.Entities;
using MongoDB.Bson;

namespace Catalog.API.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProductById(string id);
        Task<Product> GetProductByName(string name);
        Task<List<Product>> GetProductByCategorId(string categoryId);
        Task<int> AddProduct(Product product);
        Task<int> UpdateProduct(Product product);
        Task<int> DeleteProduct(string id);
    }
}
