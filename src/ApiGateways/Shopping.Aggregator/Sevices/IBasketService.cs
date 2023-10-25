using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Sevices
{
    public interface IBasketService
    {
        Task<BasketModel> GetBasketByUserName(string userName);
    }
}
