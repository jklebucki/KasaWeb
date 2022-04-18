using AutoMapper;
using Kasa.Core.Domain;
using Kasa.Infrastructure.Commands.Company;
using Kasa.Infrastructure.Commands.Location;
using Kasa.Infrastructure.DTO;

namespace Kasa.Infrastructure.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static IMapper InitAutoMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<Company, CompanyDTO>();
                cfg.CreateMap<Location, LocationDTO>();
                cfg.CreateMap<CreateLocation, Location>()
                    .ForMember(x => x.BankAccounts, o => o.Ignore())
                    .IgnoreAllPropertiesWithAnInaccessibleSetter()
                    .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
                cfg.CreateMap<UpdateCompany, Company>()
                    .ForMember(x => x.CreatedAt, o => o.Ignore())
                    .ForMember(x => x.UpdatedAt, o => o.Ignore())
                    .ForMember(x => x.Locations, o => o.Ignore())
                    .IgnoreAllPropertiesWithAnInaccessibleSetter()
                    .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
                cfg.CreateMap<CreateCompany, Company>()
                    .IgnoreAllPropertiesWithAnInaccessibleSetter()
                    .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            });
            configuration.AssertConfigurationIsValid();
            return configuration.CreateMapper();
        }
    }
}