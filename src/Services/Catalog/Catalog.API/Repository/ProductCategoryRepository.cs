using Catalog.API.Context;
using Catalog.API.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.API.Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly ICatalogContext _context;

        public ProductCategoryRepository(ICatalogContext context)
        {
            _context = context;
        }

        public async Task<List<ProductCategory>> GetProductCategories()
        {
            var categories = await _context.ProductCategories.Find(x => true && !x.IsDeleted).ToListAsync();
            return categories;
        }

        public async Task<ProductCategory> GetProductCategoryById(string id)
        {
            FilterDefinition<ProductCategory> filter = Builders<ProductCategory>.Filter.Eq(x => x.Id, id) & Builders<ProductCategory>.Filter.Eq(x => x.IsDeleted, false);

            var productCategory = await _context.ProductCategories.Find(filter).FirstOrDefaultAsync();
            return productCategory;
        }

        public async Task<int> AddProductCategory(ProductCategory productCategory)
        {
            try
            {
                await _context.ProductCategories.InsertOneAsync(productCategory);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<int> UpdateProductCategory(ProductCategory productCategory)
        {
            var updatedProductCategory = await _context.ProductCategories.FindOneAndReplaceAsync(x => x.Id == productCategory.Id && !x.IsDeleted, replacement: productCategory);
            if (updatedProductCategory == null) return 0;

            return 1;
        }

        public async Task<int> DeleteProductCategory(string id)
        {
            FilterDefinition<ProductCategory> filter = Builders<ProductCategory>.Filter.Eq(x => x.Id, id) & Builders<ProductCategory>.Filter.Eq(x => x.IsDeleted, false);

            var productCategory = await _context.ProductCategories.Find(filter).FirstOrDefaultAsync();
            if (productCategory == null) return 0;

            productCategory.IsDeleted = true;
            return 1;
        }
    }
}
