using System.Linq;
using Shared.Model;
using Order = EasyCargo.Api.Queries.Domains.Order;

namespace EasyCargo.Api.Queries.Mapping
{
    public static class OrderMapping
    {
        public static OrderResponse? DomainToResponse(this Order? order)
        {
            if (order != null)
                return new OrderResponse
                {
                    CargoKey = order.CargoKey,
                    Id = order.Id,
                    ShippingProvider = order.ShippingProvider,
                    IsShipped = order.IsShipped,
                    Products = ProductMapping.DomainToResponse(order.Products)
                };
            return null;
        }
        public static Order ResponseToDomain(this OrderResponse  orderResponse)
        {
            return new Order
            {
                Id = orderResponse.Id,
                CargoKey = orderResponse.CargoKey,
                ShippingProvider = orderResponse.ShippingProvider,
                IsShipped = orderResponse.IsShipped,
                Products =  orderResponse.Products!.Select(response => response.ResponseToDomain()).ToList()
            };
        }
    }
}
