using ShoppingApp.Models;

namespace ShoppingApp.Services
{
    public interface IProductCategoryService
    {
        Task<IEnumerable<ProductCategoryModel>> GetProductCategory();
        Task<ProductCategoryModel> CreateProductCategory(ProductCategoryModel model);
    }
}
