using CountriesDataApp.Core.Models;

namespace CountriesDataApp.Core.Filters.Interfaces
{
    public interface ICountryDataFilterEU
    {
        IEnumerable<string> ExcludedTerritories { get; set; }

        IEnumerable<Country> FilterCountriesEU(
            IEnumerable<CountryCapital> capitalsEU, IEnumerable<Country> countries);

        Country FilterCountryByName(IEnumerable<CountryCapital> capitals,
            IEnumerable<Country> countries, string name);

        IEnumerable<Country> FilterTopTenCountries(
            IEnumerable<CountryCapital> capitalsEU, IEnumerable<Country> countries, bool byDensity);
    }
}