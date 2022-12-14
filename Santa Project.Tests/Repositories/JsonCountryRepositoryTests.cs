using Santa_Project.Data;
using Santa_Project.Models;

namespace Santa_Project.Tests.Repositories
{
    public class JsonCountryRepositoryTests
    {
        [Fact]
        public void GetCountryByNameShouldReturnCorrectCountry()
        {
            // arrange
            var expectedCountry = new CountryModel
            {
                Name = Guid.NewGuid().ToString(),
                ForecastedWeather = "rain",
                InitialPayload = 20,
                Coordinates = new Coordinates { X = 10, Y = 10 }
            };

            TestJsonCountryRepository.Countries.Add(expectedCountry);
            var sut = new TestJsonCountryRepository();

            // act
            var country = sut.GetCountryByName(expectedCountry.Name);

            // assert
            Assert.Equal(expectedCountry, country);
        }

        [Fact]
        public void GetCountryByNameShouldThrowExceptionWhenGivenCountryNameNotInDataSet()
        {
            // arrange
            var sut = new TestJsonCountryRepository();

            // act & assert
            Assert.Throws<ArgumentException>(() => sut.GetCountryByName("fail"));

        }
    }

    public class TestJsonCountryRepository : JsonCountryRepository
    {
        public static readonly List<CountryModel> Countries = new();
        // template pattern instead of moq
        public override List<CountryModel> LoadJson()
        {
            return Countries;
        }
    }
}