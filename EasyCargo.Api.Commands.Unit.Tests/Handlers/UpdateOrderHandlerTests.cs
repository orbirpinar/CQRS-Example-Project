using System;
using System.Threading;
using System.Threading.Tasks;
using EasyCargo.Api.Commands.Order;
using EasyCargo.Api.Commands.Tests.Mapping;
using EasyCargo.Api.Handlers.Order;
using EasyCargo.Api.Repositories.Interfaces;
using EasyCargo.Api.Requests;
using FluentAssertions;
using Moq;
using Xunit;

namespace EasyCargo.Api.Commands.Tests.Handlers
{
    public class UpdateOrderHandlerTests: MappingConfigurationTest
    {
        private readonly UpdateOrderHandler _sut;
        private readonly Mock<IOrderRepository> _mockRepo = new();

        public UpdateOrderHandlerTests()
        {
            _sut = new UpdateOrderHandler(_mockRepo.Object, GetMapperConfiguration());
        }

        [Fact]
        public async Task Handle_WhenGivenIdExists_ShouldReturnTrue()
        {
            // Arrange
            var id = Guid.NewGuid();
            _mockRepo.Setup(repo => repo.UpdateAsync(It.IsAny<Domains.Order>(), id))
                .ReturnsAsync(true);
            // Act
            var result = await _sut.Handle(new UpdateOrderCommand(id, It.IsAny<UpdateOrderRequest>()),CancellationToken.None);
            
            // Assert
            result.Should().BeTrue();

        }

    }
}