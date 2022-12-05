using AutoMapper;
using CountriesDataApp.Core.AutoMapper.Models;
using CountriesDataApp.Core.Filters.Interfaces;
using CountriesDataApp.Services.Data.IDataServiceEU;
using Microsoft.AspNetCore.Mvc;

namespace CountriesDataApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesControllerEU : ControllerBase
    {
        private readonly IDataServiceEU _dataService;
        private readonly ICountryDataFilterEU _filterService;
        private readonly IMapper _mapper;

        public CountriesControllerEU(IDataServiceEU dataService,
            ICountryDataFilterEU filterService, IMapper mapper)
        {
            _dataService = dataService;
            _filterService = filterService;
            _mapper = mapper;
        }

        [HttpGet, Route("european-union/population/top10")]
        public async Task<IActionResult> GetTopTenCountriesByPopData(bool byDensity)
        {
            var capitalsEU = await _dataService.GetAllCapitalsEUAsync();
            var countriesEurope = await _dataService.GetAllCountriesEuropeAsync();

            var request = _filterService.FilterTopTenCountries(capitalsEU, countriesEurope, byDensity);

            return request.Any()
                ? Ok(request)
                : StatusCode(503, "Service unavailable.Try later..");
                // StatusCode is open for discussion about 404 instead of 503;
        }

        [HttpGet, Route("{name}")]
        public async Task<IActionResult> GetCountryByName(string name)
        {
            var capitalsEU = await _dataService.GetAllCapitalsEUAsync();
            var countriesEurope = await _dataService.GetAllCountriesEuropeAsync();

            var requestedCountry = _filterService.FilterCountryByName(capitalsEU, countriesEurope, name);

            return requestedCountry == null
                ? NotFound("Requested country could not be found.")
                : Ok(_mapper.Map<CountrySelectedData>(requestedCountry));
        }
    }
}
