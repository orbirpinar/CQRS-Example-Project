using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EasyCargo.Api.Commands.Order;
using EasyCargo.Api.Commands.Tests.Mapping;
using EasyCargo.Api.Domains;
using EasyCargo.Api.Handlers.Order;
using EasyCargo.Api.Producer;
using EasyCargo.Api.Repositories.Interfaces;
using EasyCargo.Api.Requests;
using FluentAssertions;
using Moq;
using Shared.Model;
using Xunit;

namespace EasyCargo.Api.Commands.Tests.Handlers
{
    public class CreateOrderHandlerTests : MappingConfigurationTest
    {
        private readonly CreateOrderHandler _sut;
        private readonly Mock<IOrderRepository> _mockRepo = new();
        private readonly Mock<IOrderProducer> _mockProducer = new();

        public CreateOrderHandlerTests()
        {
            _sut = new CreateOrderHandler(_mockRepo.Object, GetMapperConfiguration(), _mockProducer.Object);
        }

        [Fact]
        public async Task Handle_WhenMethodCalled_ShouldReturnCreateOrder()
        {
            // Arrange
            var id = Guid.NewGuid();
            _mockRepo.Setup(repo => repo.CreateAsync(It.IsAny<Domains.Order>()))
                .ReturnsAsync(GetOrder(id));
            _mockRepo.Setup(repo => repo.SaveChangesAsync());
            _mockProducer.Setup(x => x.SendAsync(GetOrderResponse(id), CancellationToken.None,EventName.OrderCreated));


            // Act
            var result = await _sut.Handle(new CreateOrderCommand(GetOrderRequest()), CancellationToken.None);

            // Assert
            result.Should().BeOfType<OrderResponse>();
            result.Should().BeEquivalentTo(GetOrderResponse(id));
            _mockProducer.Verify(x => x.SendAsync(It.Is<OrderResponse>(response => response.IsShipped.Equals(false)), 
                It.IsAny<CancellationToken>(),EventName.OrderCreated),Times.Once);
        }

        private static Domains.Order GetOrder(Guid id)
        {
            return new Domains.Order
            {
                Id = id,
                CargoKey = "123",
                ShippingProvider = 1,
                IsShipped = false,
                Products = new List<Product>()
            };
        }

        private static OrderResponse GetOrderResponse(Guid id)
        {
            return new OrderResponse
            {
                Id = id,
                CargoKey = "123",
                ShippingProvider = 1,
                IsShipped = false,
                Products = new List<ProductResponse>()
            };
        }

        private static CreateOrderRequest GetOrderRequest()
        {
            return new CreateOrderRequest
            {
                CargoKey = "123",
                IsShipped = false,
                ShippingProvider = 1,
                Products = new List<CreateProductRequest>()
            };
        }
    }
}
