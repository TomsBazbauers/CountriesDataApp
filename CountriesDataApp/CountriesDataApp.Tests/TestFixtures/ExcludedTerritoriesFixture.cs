namespace CountriesDataApp.Tests.TestFixtures
{
    public static class ExcludedTerritoriesFixture
    {
        public static IEnumerable<string> GetExcludedTerritoriesEU()
        {
            return new List<string>()
            {
                "Gibraltar",
                "Åland Islands",
                "Isle of Man"
            };
        }
    }
}
