using System;
using System.Threading.Tasks;
using EasyCargo.Api.Commands.Order;
using EasyCargo.Api.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Model;

namespace EasyCargo.Api.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("orders/{orderId:guid}/products/attach")]
        public async Task<ActionResult<OrderResponse?>> Attach([FromBody] AttachProductRequest productRequest, Guid orderId)
        {
            var response = await _mediator.Send(new AttachProductCommand(orderId, productRequest));
            return Ok(response);
        }
    }
}