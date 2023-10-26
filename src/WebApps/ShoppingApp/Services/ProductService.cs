using ShoppingApp.Extensions;
using ShoppingApp.Models;

namespace ShoppingApp.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;

        public ProductService(HttpClient client)
        {
            _client = client;
        }

        public async Task<ProductDtoModel> CreateProduct(ProductDtoModel model)
        {
            var response = await _client.PostAsJson("Product", model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductDtoModel>();
            else
                throw new Exception("Somerhing went wrong.");
        }

        public async Task<ProductDtoModel> GetProduct(string id)
        {
            var response = await _client.GetAsync($"Product/ById/{id}");
            return await response.ReadContentAs<ProductDtoModel>();
        }

        public async Task<IEnumerable<ProductDtoModel>> GetProducts()
        {
            var response = await _client.GetAsync("Product");
            return await response.ReadContentAs<IEnumerable<ProductDtoModel>>();
        }

        public async Task<IEnumerable<ProductDtoModel>> GetProductsByCategory(string categoryId)
        {
            var response = await _client.GetAsync($"Product/GetProductByCategoryId?id={categoryId}");
            return await response.ReadContentAs<IEnumerable<ProductDtoModel>>();
        }
    }
}
