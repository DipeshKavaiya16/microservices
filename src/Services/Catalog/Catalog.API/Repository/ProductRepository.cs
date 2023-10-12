using Catalog.API.Context;
using Catalog.API.Entities;
using MongoDB.Driver;
using MongoDB.Driver.Core.Authentication;

namespace Catalog.API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _context;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductRepository(ICatalogContext context, IProductCategoryRepository productCategoryRepository)
        {
            _context = context;
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<List<Product>> GetProducts()
        {
            var products = await _context.Products.Aggregate().ToListAsync();
            return products;
        }

        public async Task<Product> GetProductById(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(x => x.Id, id);
            var product = await _context.Products.Find(filter).FirstOrDefaultAsync();
            return product;
        }

        public async Task<Product> GetProductByName(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(x => x.Name, name);
            var product = await _context.Products.Find(filter).FirstOrDefaultAsync();;
            return product;
        }

        public async Task<List<Product>> GetProductByCategorId(string categoryId)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(x => x.CategoryId, categoryId);
            var products = await _context.Products.Find(filter).ToListAsync();
            return products;
        }

        public async Task<int> AddProduct(Product product)
        {
            try
            {
                await _context.Products.InsertOneAsync(product);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<int> UpdateProduct(Product product)
        {
            var updatedProduct = await _context.Products.FindOneAndReplaceAsync(x => x.Id == product.Id, replacement: product);
            if (updatedProduct == null) return 0;

            return 1;
        }

        public async Task<int> DeleteProduct(string id)
        {
            var deletedProduct = await _context.Products.FindOneAndDeleteAsync(x => x.Id == id);
            if (deletedProduct == null) return 0;

            return 1;
        }
    }
}
