using System;
using System.Threading.Tasks;
using EasyCargo.Api.Commands.Order;
using EasyCargo.Api.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Model;

namespace EasyCargo.Api.Controllers
{
    [Route("api/v1/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<ActionResult<OrderResponse>> Create([FromBody] CreateOrderRequest createOrderRequest)
        {
            return await _mediator.Send(new CreateOrderCommand(createOrderRequest));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromBody] UpdateOrderRequest updateOrderRequest, Guid id)
        {
            await _mediator.Send(new UpdateOrderCommand(id, updateOrderRequest));
            return Ok();
        }
    }
}