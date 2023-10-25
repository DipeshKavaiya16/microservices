using Shopping.Aggregator.Extensions;
using Shopping.Aggregator.Models;
using System.Text.Json;

namespace Shopping.Aggregator.Sevices
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _client;

        public BasketService(HttpClient client)
        {
            _client = client;
        }

        public async Task<BasketModel> GetBasketByUserName(string userName)
        {
            var response = await _client.GetAsync($"Basket/{userName}");
            return await response.ReadContentAs<BasketModel>();
        }
    }
}
