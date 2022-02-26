using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyCargo.Api.Commands.Order;
using EasyCargo.Api.Handlers;
using EasyCargo.Api.Queries;
using EasyCargo.Api.Requests;
using EasyCargo.Api.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyCargo.Api.Controllers
{
    
    [Route("api/v1/orders")]
    [ApiController]
    public class OrdersController: ControllerBase
    {

        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<ActionResult<List<OrderResponse>>> GetAll()
        {
            return await _mediator.Send(new GetAllOrdersQuery());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<OrderResponse>> GetById(Guid id)
        {
            var response = await _mediator.Send(new GetOrderByIdQuery(id));
            if (response is null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<OrderResponse>> Create([FromBody] CreateOrderRequest createOrderRequest)
        { 
            return await _mediator.Send(new CreateOrderCommand(createOrderRequest));
            
        }
    }
}