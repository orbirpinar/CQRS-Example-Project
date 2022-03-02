using EasyCargo.Api.Domains;
using Shared.Model;

namespace EasyCargo.Api.Mapping.Profile
{
    public class ResponseToDomainProfile: AutoMapper.Profile
    {
        public ResponseToDomainProfile()
        {
            CreateMap<ProductResponse, Product>();
            CreateMap<OrderResponse, Order>();
        }
    }
}