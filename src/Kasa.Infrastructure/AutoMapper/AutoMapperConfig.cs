using AutoMapper;
using Kasa.Core.Domain;
using Kasa.Infrastructure.DTO;

namespace Kasa.Infrastructure.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static IMapper InitAutoMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
            });
            configuration.AssertConfigurationIsValid();
            return configuration.CreateMapper();
        }
    }
}