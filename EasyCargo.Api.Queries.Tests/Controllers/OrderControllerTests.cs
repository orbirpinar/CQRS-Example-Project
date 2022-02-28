using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyCargo.Api.Queries.Controllers;
using MediatR;
using Moq;
using Shared.Model;
using Xunit;

namespace EasyCargo.Api.Queries.Tests.Controllers
{
    public class OrderControllerTests
    {
        private readonly OrderController _sut;
        private readonly Mock<IMediator> _mock = new();

        public OrderControllerTests()
        {
            _sut = new OrderController(_mock.Object);
        }

        [Fact]
        public async Task GetById_WhenGivenIdIsValid_ShouldReturnOkWithOrderResponse()
        {
            // TODO: Write integration test
            throw new NotImplementedException();
        }

        private static OrderResponse GetOrderResponseTest(Guid id)
        {
            return new OrderResponse
            {
                CargoKey = "123",
                Id = id,
                IsShipped = false,
                ShippingProvider = 2,
                Products = new List<ProductResponse>()
            };
        }
    }
}