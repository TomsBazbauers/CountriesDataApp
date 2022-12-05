namespace CountriesDataApp.Tests.Core.Tests.Filters
{
    public class CountryDataFilterEUTests
    {
        private readonly ICountryDataFilterEU _sut;
        private readonly Mock<ICountryDataSorter> _mockDataSorter;

        public CountryDataFilterEUTests()
        {
            _mockDataSorter = new Mock<ICountryDataSorter>();
            _sut = new CountryDataFilterEU(_mockDataSorter.Object);
        }

        [Fact]
        public void FilterCountriesEU_ReturnsListContainingOnlyEUCountries()
        {
            // Arrange
            var testCapitals = CountryCapitalFixture.GetCapitalsEU().ToList();
            var testCountries = CountryFixture.GetCountriesEU().ToList();

            var testListFiltered = testCountries
                .Where(country => testCapitals
                .Any(city => city.Name == country.Name.Common)
                && !_sut.ExcludedTerritories.Contains(country.Name.Common)).ToList();

            // Act
            var actual = _sut.FilterCountriesEU(testCapitals, testCountries);

            // Assert
            actual.Should().BeOfType<List<Country>>();
            actual.All(c => testListFiltered.Contains(c)).Should().BeTrue();
        }

        [Theory]
        [InlineData("Germany")]
        [InlineData("France")]
        [InlineData("Netherlands")]
        public void FilterCountryByName_InputValid_ReturnsCorrectCountry(string testName)
        {
            // Arrange
            var testCapitals = CountryCapitalFixture.GetCapitalsEU();
            var testCountries = CountryFixture.GetCountriesEU();

            // Act
            var actual = _sut.FilterCountryByName(testCapitals, testCountries, testName);

            // Assert
            actual.Should().BeOfType<Country>();
            actual.Name.Common.Should().Be(testName);
        }

        [Theory]
        [InlineData("TestParameter")]
        [InlineData("Nothing")]
        [InlineData("Francese")]
        public void FilterCountryByName_InputInvalid_ReturnsNull(string testName)
        {
            // Arrange
            var testCapitals = CountryCapitalFixture.GetCapitalsEU();
            var testCountries = CountryFixture.GetCountriesEU();

            // Act
            var actual = _sut.FilterCountryByName(testCapitals, testCountries, testName);

            // Assert
            actual.Should().Be(null);
        }

        [Fact]
        public void FilterTopTenCountries_ByDensityTrue_ReturnsListSortedByPopDensity()
        {
            // Arrange
            var testCapitals = CountryCapitalFixture.GetCapitalsEU();
            var testCountries = CountryFixture.GetCountriesEU();

            var filteredCountries = testCountries
                .Where(country => testCapitals
                .Any(city => city.Name == country.Name.Common)
                && !_sut.ExcludedTerritories.Contains(country.Name.Common)).ToList();

            var sortedCountries = filteredCountries
                .OrderByDescending(c => c.Population / c.Area).Take(10).ToList();

            _mockDataSorter
                .Setup(m => m.OrderCountriesByPopDensity(filteredCountries)).Returns(sortedCountries);

            // Act
            var actual = _sut.FilterTopTenCountries(testCapitals, testCountries, true);

            // Assert
            actual.Should().BeOfType<List<Country>>();
            actual.Count().Should().Be(10);
            actual.First().Should().Be(sortedCountries.First());
            actual.Last().Should().Be(sortedCountries.Last());
        }

        [Fact]
        public void FilterTopTenCountries_ByDensityFalse_ReturnsListSortedByPopulation()
        {
            // Arrange
            var testCapitals = CountryCapitalFixture.GetCapitalsEU();
            var testCountries = CountryFixture.GetCountriesEU();

            var filteredCountries = testCountries
                .Where(country => testCapitals
                .Any(city => city.Name == country.Name.Common)
                && !_sut.ExcludedTerritories.Contains(country.Name.Common)).ToList();

            var sortedCountries = filteredCountries
                .OrderByDescending(c => c.Population).Take(10).ToList();

            _mockDataSorter
                .Setup(m => m.OrderCountriesByPopulation(filteredCountries)).Returns(sortedCountries);

            // Act
            var actual = _sut.FilterTopTenCountries(testCapitals, testCountries, false);

            // Assert
            actual.Should().BeOfType<List<Country>>();
            actual.First().Should().Be(sortedCountries.First());
            actual.Last().Should().Be(sortedCountries.Last());
            (actual.First().Population > actual.Last().Population).Should().BeTrue();
        }
    }
}