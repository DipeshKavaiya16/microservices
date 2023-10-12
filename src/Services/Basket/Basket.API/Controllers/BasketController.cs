using Basket.API.Entities;
using Basket.API.GrpcService;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;
        private readonly DiscountGrpcService _discountGrpcService;

        public BasketController(IBasketRepository basketRepository, DiscountGrpcService discountGrpcService)
        {
            _basketRepository = basketRepository;
            _discountGrpcService = discountGrpcService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket(string userName)
        {
            var basket = await _basketRepository.GetBasket(userName);
            return Ok(basket ?? new ShoppingCart(userName));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBasket(ShoppingCart shoppingCart)
        {
            foreach (var item in shoppingCart.Items)
            {
                var coupon = await _discountGrpcService.GetDiscount(item.ProductName);
                item.Price -= coupon.Amount;
            }

            return Ok(await _basketRepository.UpdateBasket(shoppingCart));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteBasket(string userName)
        {
            await _basketRepository.DeleteBasket(userName);
            return Ok();
        }
    }
}
