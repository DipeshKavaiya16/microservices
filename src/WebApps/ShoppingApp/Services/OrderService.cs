using ShoppingApp.Extensions;
using ShoppingApp.Models;

namespace ShoppingApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _client;

        public OrderService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName)
        {
            var response = await _client.GetAsync($"Order/GetOrdersByUserName?userName={userName}");
            return await response.ReadContentAs<IEnumerable<OrderResponseModel>>();
        }
    }
}