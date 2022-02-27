using EasyCargo.Api.Domains;
using EasyCargo.Api.Requests;

namespace EasyCargo.Api.Mapping.Profile
{
    public class RequestToDomainProfile : AutoMapper.Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<CreateProductRequest, Product>();
            CreateMap<CreateOrderRequest, Order>();
            CreateMap<UpdateOrderRequest, Order>();
        }
    }
}