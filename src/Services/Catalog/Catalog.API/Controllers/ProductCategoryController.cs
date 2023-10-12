using Catalog.API.Entities;
using Catalog.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryController(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductCategories()
        {
            var categories = await _productCategoryRepository.GetProductCategories();
            return Ok(categories);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductCategoryById(string id)
        {
            var productCategory = await _productCategoryRepository.GetProductCategoryById(id);
            return Ok(productCategory);
        }

        [HttpPost]
        public async Task<ActionResult> AddProductCategory(ProductCategory productCategory)
        {
            var flag = await _productCategoryRepository.AddProductCategory(productCategory);
            return flag != 0 ? Ok("Product category added successfully.") : BadRequest("Unable to add product category.");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProductCategory(ProductCategory productCategory)
        {
            var flag = await _productCategoryRepository.UpdateProductCategory(productCategory);
            return flag != 0 ? Ok("Product category updated successfully.") : BadRequest("Unable to update product category.");
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProductCategory(string id)
        {
            var flag = await _productCategoryRepository.DeleteProductCategory(id);
            return flag != 0 ? Ok("Product category deleted successfully.") : BadRequest("Unable to delete product category.");
        }
    }
}
