using Microsoft.AspNetCore.Mvc;
using Shopping.Aggregator.Models;
using Shopping.Aggregator.Sevices;

namespace Shopping.Aggregator.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private readonly ICatalogService _catalogService;
        private readonly IBasketService _basketService;
        private readonly IOrderService _orderService;

        public ShoppingController(ICatalogService catalogService, IBasketService basketService, IOrderService orderService)
        {
            _catalogService = catalogService;
            _basketService = basketService;
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetShopping(string userName)
        {
            var basket = await _basketService.GetBasketByUserName(userName);
            if (basket is not null && basket.Items is not null)
            {
                foreach (var item in basket.Items)
                {
                    var product = await _catalogService.GetCatalogById(item.ProductId);
                    if (product is not null)
                        item.Product = product;
                }
            }

            var orders = await _orderService.GetOrdersByUserName(userName);
            var shoppingModel = new ShoppingModel()
            {
                UserName = userName,
                BasketWithProducts = basket,
                Orders = orders
            };

            return Ok(shoppingModel);
        }
    }
}
