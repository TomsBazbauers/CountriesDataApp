using Microsoft.AspNetCore.Mvc;

namespace CountriesDataApp.Tests.API.Tests.Controllers
{
    public class CountriesControllerEUTests
    {
        private readonly CountriesControllerEU _sut;
        private readonly Mock<IDataServiceEU> _mockDataService;
        private readonly Mock<ICountryDataFilterEU> _mockFilterService;
        private readonly Mock<IMapper> _mockMapper;

        public CountriesControllerEUTests()
        {
            _mockDataService = new Mock<IDataServiceEU>();
            _mockFilterService = new Mock<ICountryDataFilterEU>();
            _mockMapper = new Mock<IMapper>();

            _sut = new CountriesControllerEU(_mockDataService.Object, _mockFilterService.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetTopTenEUCountriesByPop_ByDensityTrue_ReturnsCode200AndCorrectList()
        {
            // Arrange
            var testExcludedTerritories = ExcludedTerritoriesFixture.GetExcludedTerritoriesEU();
            var testCapitals = CountryCapitalFixture.GetCapitalsEU();
            var testCountries = CountryFixture.GetCountriesEU();

            var filteredCountries = testCountries
                .Where(country => testCapitals
                .Any(city => city.Name == country.Name.Common)
                && !testExcludedTerritories.Contains(country.Name.Common));

            var sortedCountries = filteredCountries
                .OrderByDescending(c => c.Population / c.Area).Take(10);

            _mockDataService
                .Setup(m => m.GetAllCapitalsEUAsync()).ReturnsAsync(testCapitals);

            _mockDataService
                .Setup(m => m.GetAllCountriesEuropeAsync()).ReturnsAsync(testCountries);

            _mockFilterService
                .Setup(m => m.
                FilterTopTenCountries(testCapitals, testCountries, true))
                .Returns(sortedCountries.ToList());

            // Act
            var actual = await _sut.GetTopTenCountriesByPopData(true);

            // Assert
            actual.Should().BeOfType<OkObjectResult>();

            // Assert
            var actualValue = (OkObjectResult)actual;

            actualValue.StatusCode.Should().Be(200);
            actualValue.Value.Should().BeOfType<List<Country>>();
            ((List<Country>)actualValue.Value).Count().Should().Be(10);
            ((List<Country>)actualValue.Value).First().Should().Be(sortedCountries.First());
            ((List<Country>)actualValue.Value).Last().Should().Be(sortedCountries.Last());
        }

        [Fact]
        public async Task GetTopTenEUCountriesByPop_ByDensityTrue_ReturnsCode503AndMessage()
        {
            // Arrange
            _mockDataService
                .Setup(m => m.GetAllCapitalsEUAsync()).ReturnsAsync(new List<CountryCapital>());

            _mockDataService
                .Setup(m => m.GetAllCountriesEuropeAsync()).ReturnsAsync(new List<Country>());

            _mockFilterService
                .Setup(m => m.
                FilterTopTenCountries(new List<CountryCapital>(), new List<Country>(), true))
                .Returns(new List<Country>().ToList());

            // Act
            var actual = await _sut.GetTopTenCountriesByPopData(true);

            // Assert
            actual.Should().BeOfType<ObjectResult>();

            // Assert
            ((ObjectResult)actual).StatusCode.Should().Be(503);
            ((ObjectResult)actual).Value.Should().Be("Service unavailable.Try later..");
        }

        [Fact]
        public async Task GetTopTenEUCountriesByPop_ByDensityFalse_ReturnsCode200AndCorrectList()
        {
            // Arrange
            var testExcludedTerritories = ExcludedTerritoriesFixture.GetExcludedTerritoriesEU();
            var testCapitals = CountryCapitalFixture.GetCapitalsEU();
            var testCountries = CountryFixture.GetCountriesEU();

            var filteredCountries = testCountries
                .Where(country => testCapitals
                .Any(city => city.Name == country.Name.Common)
                && !testExcludedTerritories.Contains(country.Name.Common));

            var sortedCountries = filteredCountries
                .OrderByDescending(c => c.Population).Take(10);

            _mockDataService
                .Setup(m => m.GetAllCapitalsEUAsync()).ReturnsAsync(testCapitals);

            _mockDataService
                .Setup(m => m.GetAllCountriesEuropeAsync()).ReturnsAsync(testCountries);

            _mockFilterService
                .Setup(m => m.
                FilterTopTenCountries(testCapitals, testCountries, false)).Returns(sortedCountries.ToList());

            // Act
            var actual = await _sut.GetTopTenCountriesByPopData(false);

            // Assert
            actual.Should().BeOfType<OkObjectResult>();

            // Assert
            var actualValue = (OkObjectResult)actual;

            actualValue.StatusCode.Should().Be(200);
            actualValue.Value.Should().BeOfType<List<Country>>();
            ((List<Country>)actualValue.Value).Count().Should().Be(10);
            ((List<Country>)actualValue.Value).First().Should().Be(sortedCountries.First());
            ((List<Country>)actualValue.Value).Last().Should().Be(sortedCountries.Last());
        }

        [Fact]
        public async Task GetTopTenEUCountriesByPop_ByDensityFalse_ReturnsCode503AndMessage()
        {
            // Arrange
            _mockDataService
                .Setup(m => m.GetAllCapitalsEUAsync()).ReturnsAsync(new List<CountryCapital>());

            _mockDataService
                .Setup(m => m.GetAllCountriesEuropeAsync()).ReturnsAsync(new List<Country>());

            _mockFilterService
                .Setup(m => m.
                FilterTopTenCountries(new List<CountryCapital>(), new List<Country>(), true))
                .Returns(new List<Country>().ToList());

            // Act
            var actual = await _sut.GetTopTenCountriesByPopData(true);

            // Assert
            actual.Should().BeOfType<ObjectResult>();

            // Assert
            ((ObjectResult)actual).StatusCode.Should().Be(503);
            ((ObjectResult)actual).Value.Should().Be("Service unavailable.Try later..");
        }

        [Theory]
        [InlineData("Germany")]
        [InlineData("France")]
        [InlineData("Spain")]
        public async Task GetEUCountryByName_ReturnsCode200AndCorrectCountry(string testName)
        {
            // Arrange
            var testCountries = CountryFixture.GetCountriesEU();
            var testCapitals = CountryCapitalFixture.GetCapitalsEU();
            var expectedCountry = testCountries.First(c => c.Name.Common == testName);

            _mockDataService
                .Setup(m => m.GetAllCapitalsEUAsync()).ReturnsAsync(testCapitals);

            _mockDataService
                .Setup(m => m.GetAllCountriesEuropeAsync()).ReturnsAsync(testCountries);

            _mockFilterService
                .Setup(m => m.
                FilterCountryByName(testCapitals, testCountries, testName)).Returns(expectedCountry);

            _mockMapper.Setup(m => m.Map<CountrySelectedData>(expectedCountry))
                .Returns(new CountrySelectedData()
                {
                    Area = expectedCountry.Area,
                    Population = expectedCountry.Population,
                    TLD = expectedCountry.TLD.First()
                });

            // Act
            var actual = await _sut.GetCountryByName(testName);

            // Assert
            actual.Should().BeOfType<OkObjectResult>();

            var actualValue = (OkObjectResult)actual;
            actualValue.StatusCode.Should().Be(200);
            actualValue.Value.Should().BeOfType<CountrySelectedData>();
            ((CountrySelectedData)actualValue.Value).Population.Should().Be(expectedCountry.Population);
            ((CountrySelectedData)actualValue.Value).Area.Should().Be(expectedCountry.Area);
        }

        [Theory]
        [InlineData("TestName")]
        [InlineData("TestCountry")]
        [InlineData("testRequest")]
        public async Task GetEUCountryByName_CountryNotFoundReturnsCode404AndCorrectCountry(string testName)
        {
            // Arrange
            var testCountries = CountryFixture.GetCountriesEU();
            var testCapitals = CountryCapitalFixture.GetCapitalsEU();
            var expectedCountry = testCountries.FirstOrDefault(c => c.Name.Common == testName);

            _mockDataService
                .Setup(m => m.GetAllCapitalsEUAsync()).ReturnsAsync(testCapitals);

            _mockDataService
                .Setup(m => m.GetAllCountriesEuropeAsync()).ReturnsAsync(testCountries);

            _mockFilterService
                .Setup(m => m.
                FilterCountryByName(testCapitals, testCountries, testName)).Returns(expectedCountry);

            // Act
            var actual = await _sut.GetCountryByName(testName);

            // Assert
            actual.Should().BeOfType<NotFoundObjectResult>();

            var actualValue = (NotFoundObjectResult)actual;
            actualValue.StatusCode.Should().Be(404);
            actualValue.Value.Should().Be("Requested country could not be found.");
        }
    }
}