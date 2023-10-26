using ShoppingApp.Extensions;
using ShoppingApp.Models;

namespace ShoppingApp.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly HttpClient _client;

        public ProductCategoryService(HttpClient client)
        {
            _client = client;
        }

        public async Task<ProductCategoryModel> CreateProductCategory(ProductCategoryModel model)
        {
            var response = await _client.PostAsJson("ProductCategory", model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductCategoryModel>();
            else
                throw new Exception("Something went wrong.");
        }

        public async Task<IEnumerable<ProductCategoryModel>> GetProductCategory()
        {
            var response = await _client.GetAsync("ProductCategory");
            return await response.ReadContentAs<IEnumerable<ProductCategoryModel>>();
        }
    }
}
