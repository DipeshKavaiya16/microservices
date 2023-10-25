using Shopping.Aggregator.Extensions;
using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Sevices
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _client;

        public CatalogService(HttpClient client)
        {
            _client = client;
        }

        public async Task<CatalogModel> GetCatalogById(string id)
        {
            var response = await _client.GetAsync($"Product/ById/{id}");
            return await response.ReadContentAs<CatalogModel>();
        }
    }
}
