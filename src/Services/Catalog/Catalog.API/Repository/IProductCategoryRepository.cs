using Catalog.API.Entities;
using MongoDB.Bson;

namespace Catalog.API.Repository
{
    public interface IProductCategoryRepository
    {
        Task<List<ProductCategory>> GetProductCategories();
        Task<ProductCategory> GetProductCategoryById(string id);
        Task<int> AddProductCategory(ProductCategory productCategory);
        Task<int> UpdateProductCategory(ProductCategory productCategory);
        Task<int> DeleteProductCategory(string id);
    }
}
