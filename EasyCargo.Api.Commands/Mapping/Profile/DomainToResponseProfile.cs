using EasyCargo.Api.Domains;
using Shared.Model;

namespace EasyCargo.Api.Mapping.Profile
{
    public class DomainToResponseProfile : AutoMapper.Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<Product, ProductResponse>();
            CreateMap<Order, OrderResponse>();
        }
    }
}