using System;
using System.Collections.Generic;
using System.Linq;
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
    public class GetAllOrdersHandlerTests
    {
        private readonly GetAllOrdersHandler _sut;
        private readonly Mock<IOrderReadRepository> _mock = new();

        public GetAllOrdersHandlerTests()
        {
            _sut = new GetAllOrdersHandler(_mock.Object);
        }

        [Fact]
        public async Task Handle_WhenCalled_ShouldReturnListOfOrders()
        {
            // Arrange
            _mock.Setup(repo => repo.GetAll()).ReturnsAsync(GetAllBooksTest());
            
            // Act
            var result = await _sut.Handle(new GetAllOrders(),CancellationToken.None);
            
            //Assert
            result.Should().BeOfType<List<OrderResponse>>();
            result.Count.Should().Be(2);
        }

        [Fact]
        public async Task Handle_WhenNoOrderInDb_ShouldReturnEmptyList()
        {
            
            // Arrange
            _mock.Setup(repo => repo.GetAll()).ReturnsAsync(new List<Order>());
            
            // Act
            var result = await _sut.Handle(new GetAllOrders(),CancellationToken.None);
            
            //Assert
            result.Should().BeOfType<List<OrderResponse>>();
            result.Count.Should().Be(0);
        }

        private static List<Order> GetAllBooksTest()
        {
            return new List<Order>
            {
                new()
                {
                    CargoKey = "123",
                    Id = Guid.NewGuid(),
                    IsShipped = false,
                    ShippingProvider = 2,
                    Products = new List<Product>()
                },

                new()
                {
                    CargoKey = "345",
                    Id = Guid.NewGuid(),
                    IsShipped = true,
                    ShippingProvider = 1,
                    Products = new List<Product>()
                }
            };
        }
        
    }
}