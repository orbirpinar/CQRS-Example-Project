using AutoMapper;
using EasyCargo.Api.Queries.Domains;
using EasyCargo.Api.Queries.Responses;
using Microsoft.AspNetCore.Mvc;

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