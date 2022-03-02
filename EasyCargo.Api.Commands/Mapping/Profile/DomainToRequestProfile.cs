using EasyCargo.Api.Domains;
using EasyCargo.Api.Requests;

namespace EasyCargo.Api.Mapping.Profile
{
    public class DomainToRequestProfile: AutoMapper.Profile
    {
        public DomainToRequestProfile()
        {
            CreateMap<Product, CreateProductRequest>();
            CreateMap<Order, CreateOrderRequest>();
            CreateMap<Order, UpdateOrderRequest>();
        }
        
    }
}