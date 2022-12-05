using CountriesDataApp.Core.Models;

namespace CountriesDataApp.Core.Helpers.Interfaces
{
    public interface ICountryDataSorter
    {
        IEnumerable<Country> OrderCountriesByPopulation(IEnumerable<Country> countries);

        IEnumerable<Country> OrderCountriesByPopDensity(IEnumerable<Country> countries);
    }
}
