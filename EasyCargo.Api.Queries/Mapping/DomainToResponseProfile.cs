using AutoMapper;
using EasyCargo.Api.Queries.Domains;
using Shared.Model;

namespace EasyCargo.Api.Queries.Mapping
{
    public class DomainToResponseProfile: Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<Product, ProductResponse>();
            CreateMap<Order, OrderResponse>();
        }
    }
}