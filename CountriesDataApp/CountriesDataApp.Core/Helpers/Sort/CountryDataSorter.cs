using CountriesDataApp.Core.Helpers.Interfaces;
using CountriesDataApp.Core.Models;

namespace CountriesDataApp.Core.Helpers.Sort
{
    public class CountryDataSorter : ICountryDataSorter
    {
        public IEnumerable<Country> OrderCountriesByPopDensity(IEnumerable<Country> countries)
        {
            return countries.OrderByDescending(country => country.Population / country.Area);
        }

        public IEnumerable<Country> OrderCountriesByPopulation(IEnumerable<Country> countries)
        {
            return countries.OrderByDescending(country => country.Population);
        }
    }
}