using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Context
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);

            Products = database.GetCollection<Product>(configuration["DatabaseSettings:ProductCollection"]);
            ProductCategories = database.GetCollection<ProductCategory>(configuration["DatabaseSettings:ProductCategoryCollection"]);
        }

        public IMongoCollection<Product> Products { get; set; }
        public IMongoCollection<ProductCategory> ProductCategories { get; set; }
    }
}
