using CountriesDataApp.Core.Filters.Interfaces;
using CountriesDataApp.Core.Helpers.Interfaces;
using CountriesDataApp.Core.Models;

namespace CountriesDataApp.Core.Filters.EUCountries
{
    public class CountryDataFilterEU : ICountryDataFilterEU
    {
        private readonly ICountryDataSorter _dataSorter;
        private IEnumerable<string> _excludedTerritories = new List<string>()
        {
            "Gibraltar",
            "Åland Islands",
            "Isle of Man"
        };

        public CountryDataFilterEU(ICountryDataSorter dataSorter)
        {
            _dataSorter = dataSorter;
        }

        public IEnumerable<string> ExcludedTerritories
        {
            get => _excludedTerritories;
            set => _excludedTerritories = value;
        }

        public IEnumerable<Country> FilterCountriesEU(
            IEnumerable<CountryCapital> capitals, IEnumerable<Country> countries)
        {
            var countriesEU = countries
                .Where(country => capitals.Any(city => city.Name == country.Name.Common)
                && !_excludedTerritories.Contains(country.Name.Common)).ToList();

            return countriesEU;
        }

        public Country FilterCountryByName(IEnumerable<CountryCapital> capitals,
            IEnumerable<Country> countries, string name)
        {
            var countriesEU = FilterCountriesEU(capitals, countries);

            return countriesEU.FirstOrDefault(country => country.Name.Common.ToLower() == name.ToLower());
        }

        public IEnumerable<Country> FilterTopTenCountries(
            IEnumerable<CountryCapital> capitals, IEnumerable<Country> countries, bool byDensity)
        {
            var countriesEU = FilterCountriesEU(capitals, countries);

            return byDensity
                ? _dataSorter.OrderCountriesByPopDensity(countriesEU).Take(10).ToList()
                : _dataSorter.OrderCountriesByPopulation(countriesEU).Take(10).ToList();
        }
    }
}