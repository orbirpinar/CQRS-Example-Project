using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyCargo.Api.Queries.Domains;
using EasyCargo.Api.Queries.Queries;
using EasyCargo.Api.Queries.Repositories.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Model;
using Order = EasyCargo.Api.Queries.Domains.Order;

namespace EasyCargo.Api.Queries.Controllers
{
    [ApiController]
    [Route("api/v1/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IOrderWriteRepository _orderWriteRepository;

        public OrderController(IMediator mediator, IOrderWriteRepository orderWriteRepository)
        {
            _mediator = mediator;
            _orderWriteRepository = orderWriteRepository;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<OrderResponse>> GetById(Guid id)
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
                IsShipped = false,
            };

            var products = new List<Product>();
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Width = 12,
                Height = 2,
                Deci = 12,
                Depth = 2,
                Qty = 12
            };
            products.Add(product);
            order.Products = products;
            await _orderWriteRepository.CreateAsync(order);
        }
    }
}