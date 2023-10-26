using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingApp.Models;
using ShoppingApp.Services;

namespace ShoppingApp.Pages
{
    public class ProductModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IBasketService _basketService;

        public ProductModel(IProductService productService, IProductCategoryService productCategoryService, IBasketService basketService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
            _basketService = basketService;
        }

        public IEnumerable<ProductCategoryModel> CategoryList { get; set; } = new List<ProductCategoryModel>();
        public IEnumerable<ProductDtoModel> ProductList { get; set; } = new List<ProductDtoModel>();


        [BindProperty(SupportsGet = true)]
        public string SelectedCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(string? categoryId)
        {
            CategoryList = await _productCategoryService.GetProductCategory();

            if (categoryId is not null)
            {
                ProductList = await _productService.GetProductsByCategory(categoryId);
                SelectedCategory = CategoryList.FirstOrDefault(c => c.Id == categoryId).Name;
            }
            else
            {
                ProductList = await _productService.GetProducts(); ;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(string productId)
        {
            var product = await _productService.GetProduct(productId);
            string userName = "Dipesh Kavaiya";
            var basket = await _basketService.GetBasket(userName);
            basket.Items.Add(new BasketItemModel
            {
                ProductId = productId,
                ProductName = product.Name,
                Price = product.Price,
                Quantity = 1,
                Color = "Black"
            });

            basket.Items.ForEach(x =>
            {
                if (x.ProductId == productId)
                    x.Price = product.Price;
            });

            var basketUpdated = await _basketService.UpdateBasket(basket);

            return RedirectToPage("Cart");
        }
    }
}