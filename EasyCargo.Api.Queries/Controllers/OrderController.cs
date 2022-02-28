using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyCargo.Api.Queries.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Model;

namespace EasyCargo.Api.Queries.Controllers
{
    [ApiController]
    [Route("api/v1/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<OrderResponse>> GetById(Guid id)
        {
            var order = await _mediator.Send(new GetOrderById(id));
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        [HttpGet("")]
        public async Task<ActionResult<List<OrderResponse>>> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllOrders()));
        }
    }
}