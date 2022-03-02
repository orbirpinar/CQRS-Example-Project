using AutoMapper;
using EasyCargo.Api.Mapping.Profile;

namespace EasyCargo.Api.Commands.Tests.Mapping
{
    public class MappingConfigurationTest
    {
        protected static IMapper GetMapperConfiguration()
        {
            var mapperConfiguration = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DomainToResponseProfile());
                mc.AddProfile(new RequestToDomainProfile());
            });
            return mapperConfiguration.CreateMapper();
        }
    }
}