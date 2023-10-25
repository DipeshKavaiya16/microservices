using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Sevices
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName);
    }
}
