﻿using Discount.DataAccess.Entities;
using Discount.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Discount.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountRepository _discountRepository;

        public DiscountController(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        [HttpGet, Route("{productName}")]
        public async Task<IActionResult> GetDiscount(string productName)
        {
            var coupon = await _discountRepository.GetDiscount(productName);
            return Ok(coupon);
        }

        [HttpPost, Route("[action]")]
        public async Task<ActionResult> CreateDiscount(Coupon coupon)
        {
            var flag = await _discountRepository.CreateDiscount(coupon);
            return flag ? Ok("Coupon added successfully.") : BadRequest("Unable to create coupon.");
        }

        [HttpPut, Route("[action]")]
        public async Task<ActionResult> UpdateDiscount(Coupon coupon)
        {
            var flag = await _discountRepository.UpdateDiscount(coupon);
            return flag ? Ok("Coupon updated successfully.") : BadRequest("Unable to update coupon.");
        }

        [HttpDelete, Route("{productName}")]
        public async Task<ActionResult> DeleteDiscount(string prooductName)
        {
            var flag = await _discountRepository.DeleteDiscount(prooductName);
            return flag ? Ok("Coupon deleted successfully.") : BadRequest("Unable to delete coupon.");
        }
    }
}
