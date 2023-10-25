using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Sevices
{
    public interface ICatalogService
    {
        Task<CatalogModel> GetCatalogById(string id);
    }
}
