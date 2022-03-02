using EasyCargo.Api.Requests;
using Shared.Model;

namespace EasyCargo.Api.Mapping.Profile
{
    public class RequestToResponseProfile: AutoMapper.Profile
    {
        public RequestToResponseProfile()
        {
            CreateMap<UpdateOrderRequest, OrderResponse>();
        }
    }
}