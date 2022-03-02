using System;
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
        public ActionResult<OrderResponse?> Attach([FromBody] AttachProductRequest productRequest, Guid orderId)
        {
            var response = _mediator.Send(new AttachProductCommand(orderId, productRequest));
            return Ok(response);
        }
    }
}