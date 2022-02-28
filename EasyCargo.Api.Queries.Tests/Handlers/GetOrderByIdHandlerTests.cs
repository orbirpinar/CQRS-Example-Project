using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EasyCargo.Api.Queries.Domains;
using EasyCargo.Api.Queries.Handlers;
using EasyCargo.Api.Queries.Queries;
using EasyCargo.Api.Queries.Repositories.Interface;
using FluentAssertions;
using Moq;
using Shared.Model;
using Xunit;

namespace EasyCargo.Api.Queries.Tests.Handlers
{
    public class GetOrderByIdHandlerTests
    {
        private readonly GetOrderByIdHandler _sut;
        private readonly Mock<IOrderReadRepository> _mock = new();

        public GetOrderByIdHandlerTests()
        {
            _sut = new GetOrderByIdHandler(_mock.Object);
        }

        [Fact]
        public async Task Handle_GivenOrderIdValid_ShouldReturnOrder()
        {
            // Arrange
            var id = Guid.NewGuid();
            _mock.Setup(repo => repo.GetById(id)).ReturnsAsync(GetOrderTest(id))
                .As<OrderResponse>();

            //Act
            var result = await _sut.Handle(new GetOrderById(id), CancellationToken.None);

            //Assert
            result.Should().BeOfType<OrderResponse>();
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(GetOrderResponseTest(id));
        }

        [Fact]
        public async Task Handle_GivenOrderIdNotInDb_ShouldReturnNull()
        {
            
            // Arrange
            var id = Guid.NewGuid();
            _mock.Setup(repo => repo.GetById(id)).ReturnsAsync(GetOrderTest(id))
                .As<OrderResponse>();

            //Act
            var result = await _sut.Handle(new GetOrderById(Guid.NewGuid()), CancellationToken.None);

            //Assert
            result.Should().BeNull();
        }

        private static Order GetOrderTest(Guid id)
        {
            return new Order
            {
                CargoKey = "123",
                Id = id,
                IsShipped = false,
                ShippingProvider = 2,
                Products = new List<Product>()
            };
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