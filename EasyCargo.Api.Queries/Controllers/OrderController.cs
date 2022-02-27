using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EasyCargo.Api.Queries.Domains;
using EasyCargo.Api.Queries.Queries;
using EasyCargo.Api.Queries.Repositories.Interface;
using EasyCargo.Api.Queries.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Entities;
using Order = EasyCargo.Api.Queries.Domains.Order;

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

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResponse>> GetById(string id)
        {
            var order = await _mediator.Send(new GetOrderById(id));
            return Ok(order);
        }

        [HttpGet("")]
        public async Task<ActionResult<List<OrderResponse>>> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllOrders()));
        }

        [HttpPost]
        public async Task Save()
        {
            Order order = new()
            {
                ShippingProvider = 1,
                CargoKey = "123",
                IsShipped = false
            };
            await order.SaveAsync();

            var product = new Product
            {
                Width = 12,
                Height = 2,
                Deci = 12,
                Depth = 2,
                Qty = 12
            };
            await product.SaveAsync();

            await order.Products?.AddAsync(product)!;
        }
    }
}