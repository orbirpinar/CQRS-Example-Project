using AutoMapper;
using EasyCargo.Api.Queries.Mapping;

namespace EasyCargo.Api.Queries.Tests.Mapping
{
    public class MapperConfigurationTest
    {
        protected virtual IMapper GetMapperConfiguration()
        {
            
            var mapperConfiguration = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DomainToResponseProfile());
                mc.AddProfile(new ResponseToDomainProfile());
            });
            return mapperConfiguration.CreateMapper();
        }
    }
}