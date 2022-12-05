using AutoMapper;
using CountriesDataApp.Core.AutoMapper.Models;
using CountriesDataApp.Core.Models;

namespace CountriesDataApp.Core.AutoMapper
{
    public class AutoMapperConfig
    {
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Country, CountrySelectedData>()
                .ForMember(c => c.TLD, p => p.MapFrom(x => x.TLD.First()));
            });

            config.AssertConfigurationIsValid();

            return config.CreateMapper();
        }
    }
}
