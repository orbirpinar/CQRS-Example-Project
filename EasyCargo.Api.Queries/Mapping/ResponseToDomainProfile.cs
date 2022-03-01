using AutoMapper;
using EasyCargo.Api.Queries.Domains;
using MongoDB.Driver;
using Shared.Model;

namespace EasyCargo.Api.Queries.Mapping
{
    public class ResponseToDomainProfile: Profile
    {
        public ResponseToDomainProfile()
        {
            CreateMap<ProductResponse, Product>();
            CreateMap<OrderResponse, Order>();
        }
    }
}