using CountriesDataApp.Core.Helpers.Sort;

namespace CountriesDataApp.Tests.Core.Tests.Helpers
{
    public class CountryDataSorterTests
    {
        private readonly ICountryDataSorter _sut;

        public CountryDataSorterTests()
        {
            _sut = new CountryDataSorter();
        }

        [Fact]
        public void OrderCountriesByPopDensity_ReturnsCountryListSortedByPopulationDensity()
        {
            // Arrange
            var testList = CountryFixture.GetCountriesEU();
            var sortedTestList = testList.OrderByDescending(c => c.Population / c.Area);

            // Act
            var actual = _sut.OrderCountriesByPopDensity(testList).ToList();

            // Assert
            actual.Should().BeOfType<List<Country>>();
            actual.Count().Should().Be(testList.Count());
            actual.First().Should().BeSameAs(sortedTestList.First());
            actual.Last().Should().BeSameAs(sortedTestList.Last());
            actual.All(c =>
                c.Population / c.Area <= actual[0].Population / actual[0].Area).Should().BeTrue();
        }

        [Fact]
        public void OrderCountriesByPopulation_ReturnsCountryListSortedByPopulation()
        {
            // Arrange
            var testList = CountryFixture.GetCountriesEU();
            var sortedTestList = testList.OrderByDescending(c => c.Population);

            // Act
            var actual = _sut.OrderCountriesByPopulation(testList).ToList();

            // Assert
            actual.Should().BeOfType<List<Country>>();
            actual.Count().Should().Be(testList.Count());
            actual.First().Should().BeSameAs(sortedTestList.First());
            actual.Last().Should().BeSameAs(sortedTestList.Last());
            actual.All(c => c.Population <= actual[0].Population).Should().BeTrue();
            (actual.First().Population > actual.Last().Population).Should().BeTrue();
        }
    }
}