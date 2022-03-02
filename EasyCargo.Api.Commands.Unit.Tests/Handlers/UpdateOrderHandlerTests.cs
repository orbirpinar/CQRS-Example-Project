using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EasyCargo.Api.Commands.Order;
using EasyCargo.Api.Handlers.Order;
using EasyCargo.Api.Mapping.Profile;
using EasyCargo.Api.Producer;
using EasyCargo.Api.Repositories.Interfaces;
using EasyCargo.Api.Requests;
using FluentAssertions;
using Moq;
using Shared.Model;
using Xunit;

namespace EasyCargo.Api.Commands.Tests.Handlers
{
    public class UpdateOrderHandlerTests
    {
        private readonly UpdateOrderHandler _sut;
        private readonly Mock<IOrderRepository> _mockRepo = new();
        private readonly Mock<IProducer> _mockProducer = new();
        private readonly IMapper _mapper;


        public UpdateOrderHandlerTests()
        {
            
            _mapper = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DomainToResponseProfile());
                mc.AddProfile(new RequestToDomainProfile());
                mc.AddProfile(new DomainToRequestProfile());
                mc.AddProfile(new ResponseToDomainProfile());
                mc.AddProfile(new RequestToResponseProfile());
            }).CreateMapper();
            _sut = new UpdateOrderHandler(_mockRepo.Object, _mapper,_mockProducer.Object);
        }

        [Fact]
        public async Task Handle_WhenGivenIdExists_ShouldReturnTrue()
        {
            // Arrange
            var id = Guid.NewGuid();
            
            _mockRepo.Setup(repo => repo.UpdateAsync(It.IsAny<Domains.Order>(), id))
                .ReturnsAsync(true);
            _mockRepo.Setup(repo => repo.SaveChangesAsync());
 
            _mockProducer.Setup(producer => producer.SendAsync(It.IsAny<OrderResponse>(), CancellationToken.None, EventName.OrderUpdated));
            
            // Act
            var result = await _sut.Handle(new UpdateOrderCommand(id,GetOrderRequest()),CancellationToken.None);
            
            // Assert
            result.Should().BeTrue();
            _mockRepo.Verify();
            _mockProducer.Verify();
        }

        private static OrderResponse GetOrderResponse()
        {
            return new OrderResponse
            {
                CargoKey = "123",
                IsShipped = false,
                ShippingProvider = 1,
                Products = new List<ProductResponse>()
            };
        }

        private  Domains.Order GetOrder()
        {
            return _mapper.Map<Domains.Order>(GetOrderResponse());
        }

        private UpdateOrderRequest GetOrderRequest()
        {
            return _mapper.Map<UpdateOrderRequest>(GetOrder());
        }
        


    }
}