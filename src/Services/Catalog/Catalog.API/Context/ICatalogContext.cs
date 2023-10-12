using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Context
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; set; }
        IMongoCollection<ProductCategory> ProductCategories { get; set; }
    }
}