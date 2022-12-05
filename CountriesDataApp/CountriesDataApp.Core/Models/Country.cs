using Newtonsoft.Json;

namespace CountriesDataApp.Core.Models
{
    public class Country
    {
        public CountryName Name { get; set; }

        public long Population { get; set; }

        public decimal Area { get; set; }

        [JsonProperty("tld")]
        public List<string> TLD { get; set; }
    }
}