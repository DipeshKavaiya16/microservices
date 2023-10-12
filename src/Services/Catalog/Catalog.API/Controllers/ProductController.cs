using Catalog.API.Entities;
using Catalog.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productRepository.GetProducts();

            return Ok(products);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductById(string id)
        {
            var product = await _productRepository.GetProductById(id);
            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductByName(string name)
        {
            var product = await _productRepository.GetProductByName(name);
            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductByCategoryId(string id)
        {
            var product = await _productRepository.GetProductByCategorId(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(Product product)
        {
            var flag = await _productRepository.AddProduct(product);
            return flag != 0 ? Ok("Product added successfully.") : BadRequest("Unable to add product.");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProduct(Product product)
        {
            var flag = await _productRepository.UpdateProduct(product);
            return flag != 0 ? Ok("Product updated successfully.") : BadRequest("Unable to update product.");
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProduct(string id)
        {
            var flag = await _productRepository.DeleteProduct(id);
            return flag != 0 ? Ok("Product deleted successfully.") : BadRequest("Unable to delete product.");
        }
    }
}
