using CountriesDataApp.Core.Models;
using Refit;

namespace CountriesDataApp.Services.Data.IDataServiceEU
{
    public interface IDataServiceEU
    {
        [Get("/v3.1/subregion/europe")]
        Task<IEnumerable<Country>> GetAllCountriesEuropeAsync();

        [Get("/v2/regionalbloc/eu?fields=name,capital")]
        Task<IEnumerable<CountryCapital>> GetAllCapitalsEUAsync();

        [Get("/v3.1/name/{name}")]
        Task<IEnumerable<Country>> GetCountryByNameAsync(string name);
    }
}
