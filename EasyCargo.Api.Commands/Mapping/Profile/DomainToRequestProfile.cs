using EasyCargo.Api.Domains;
using EasyCargo.Api.Requests;
using Shared.Model;

namespace EasyCargo.Api.Mapping.Profile
{
    public class DomainToRequestProfile : AutoMapper.Profile
    {
        public DomainToRequestProfile()
        {
            CreateMap<Product, CreateProductRequest>();
            CreateMap<Order, CreateOrderRequest>();
            CreateMap<Order, UpdateOrderRequest>();
            CreateMap<Product, ConsumingProduct>();
        }

    }
}
