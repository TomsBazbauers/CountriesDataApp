namespace CountriesDataApp.Core.Models
{
    public class CountryName
    {
        public string Common { get; set; }

        public string Official { get; set; }

        public IDictionary<string, CountryNativeName> NativeName { get; set; }
    }
}
