using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Features.Orders.Commands.CheckoutOrder;
using Ordering.Application.Features.Orders.Commands.DeleteOrder;
using Ordering.Application.Features.Orders.Commands.UpdateOrder;
using Ordering.Application.Features.Orders.Queries.GetOrdersList;
using System.Threading.Tasks;

namespace Ordering.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrdersByUserName(string userName)
        {
            var query = new GetOrdersListQuery(userName);
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        [HttpPost]
        public async Task<ActionResult> CheckoutOrder(CheckoutOrderCommand command)
        {
            var flag = await _mediator.Send(command);
            return flag > 0 ? Ok("Order created successfully.") : BadRequest("Unable to create order.");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateOrder(UpdateOrderCommand command)
        {
            var flag = await _mediator.Send(command);
            return flag > 0 ? Ok("Order updated successfully.") : BadRequest("Unable to update order.");
        }

        [HttpDelete]
        public async Task<ActionResult> UpdateOrder(int id)
        {
            var command = new DeleteOrderCommand() { Id = id };
            var flag = await _mediator.Send(command);
            return flag > 0 ? Ok("Order deleted successfully.") : BadRequest("Unable to delete order.");
        }
    }
}
