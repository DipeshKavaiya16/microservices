using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingApp.Models;
using ShoppingApp.Services;

namespace ShoppingApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;

        public CartModel(IBasketService basketService, IProductService productService)
        {
            _basketService = basketService;
            _productService = productService;
        }

        public BasketModel Cart { get; set; } = new BasketModel();

        public async Task<IActionResult> OnGetAsync()
        {
            Cart = await _basketService.GetBasket("Dipesh Kavaiya");
            foreach (var item in Cart.Items)
            {
                var product = await _productService.GetProduct(item.ProductId);
                if (product is not null)
                    item.ImageFile = product.ImageFile;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostRemoveToCartAsync(string productId)
        {
            var userName = "Dipesh Kavaiya";
            var basket = await _basketService.GetBasket(userName);
            var product = await _productService.GetProduct(productId);
            var item = basket.Items.First(x => x.ProductId == productId);
            basket.Items.Remove(item);

            basket.Items.ForEach(x =>
            {
                if (x.ProductId == productId)
                    x.Price = product.Price;
            });

            var updatedBasket = await _basketService.UpdateBasket(basket);

            return RedirectToPage();
        }
    }
}