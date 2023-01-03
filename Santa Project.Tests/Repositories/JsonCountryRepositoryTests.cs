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

            var sut = new TestJsonCountryRepository();
            sut.Countries.Add(expectedCountry);

            // act
            var country = sut.GetCountryByName(expectedCountry.Name);

            // assert
            Assert.Equal(expectedCountry, country);
        }

        [Fact]
        public void GetCountryByNameShouldBeCaseInsensitive()
        {

        }

        [Fact]
        public void GetCountryByNameShouldThrowExceptionWhenGivenCountryNameNotInDataSet()
        {
            // arrange
            var sut = new TestJsonCountryRepository();

            // act & assert
            Assert.Throws<ArgumentException>(() => sut.GetCountryByName("fail"));
        }

        [Fact]
        public void AddCountryShouldAddValidCountry()
        {
            // arrange
            var newCountry = new CountryModel
            {
                Name = "Test",
                ForecastedWeather = "",
                InitialPayload = 20,
                Coordinates = new Coordinates { X = 2, Y = 1 }
            };

            var sut = new TestJsonCountryRepository();

            // Act
            var result = sut.AddCountry(newCountry);

            // Assert
            Assert.Equal(newCountry, result);
            Assert.Contains(newCountry, sut.Countries);
            Assert.Equal(sut.Countries.Count, 1);
        }

        [Theory]
        [InlineData]
        public void AddCountryShouldBeCaseSensitive()
        {

        }

        [Fact]
        public void AddCountryShouldThrowArgumentExceptionWhenGivenCountryNameAlreadyExists()
        {
            // arrange
            var newCountry = new CountryModel
            {
                Name = "Test",
                ForecastedWeather = "",
                InitialPayload = 20,
                Coordinates = new Coordinates { X = 2, Y = 1 }
            };

            var secondCountry = new CountryModel
            {
                Name = "Test",
                ForecastedWeather = "",
                InitialPayload = 20,
                Coordinates = new Coordinates { X = 10, Y = 19 }
            };

            var sut = new TestJsonCountryRepository();
            sut.Countries.Add(newCountry);

            // Act and Assert 
            Assert.Throws<ArgumentException>(() => sut.AddCountry(newCountry));
        }

        [Fact]
        public void AddCountryShouldThrowArgumentExceptionWhenGivenCountryCoordinatesAlreadyExists()
        {
            // arrange
            var newCountry = new CountryModel
            {
                Name = "Test",
                ForecastedWeather = "fog",
                InitialPayload = 20,
                Coordinates = new Coordinates { X = 2, Y = 1 }
            };

            var secondCountry = new CountryModel
            {
                Name = "Different name",
                ForecastedWeather = "",
                InitialPayload = 20,
                Coordinates = new Coordinates { X = 2, Y = 1 }
            };

            var sut = new TestJsonCountryRepository();
            sut.Countries.Add(newCountry);

            // Act and Assert 
            Assert.Throws<ArgumentException>(() => sut.AddCountry(newCountry));
        }

        [Fact]
        public void AddCountryShouldThrowExceptionWhenGivenNull()
        {
            // arrange
            var sut = new TestJsonCountryRepository();

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => sut.AddCountry(null));
        }

        [Fact]
        public void AddCountryShouldThrowExceptionForCountryWithNoName()
        {
            // arrange
            var newCountry = new CountryModel
            {
                Name = null,
                ForecastedWeather = "",
                InitialPayload = 20,
                Coordinates = new Coordinates { X = 2, Y = 1 }
            };

            var sut = new TestJsonCountryRepository();

            Assert.Throws<ArgumentException>(() => sut.AddCountry(newCountry));
        }

        [Fact]
        public void DeleteCountryByNameShouldDeleteTheCountryViaTheGivenNameCaseInsensitive() // FIX
        {
            // arrange
            var countryToDelete = new CountryModel
            {
                Name = "Test",
                ForecastedWeather = "lol",
                InitialPayload = 4,
                Coordinates = new Coordinates { X = 3, Y = 9 }
            };

            var sut = new TestJsonCountryRepository();
            sut.Countries.Add(countryToDelete);

            // act
            sut.DeleteByName("Test");
            var test = sut.Countries;
            // assert
            Assert.Empty(sut.Countries);
        }

        [Fact]
        public void DeleteCountryByNameShouldNotDeleteACountryThatDoesntExist()
        {
            // arrange
            var newCountry = new CountryModel
            {
                Name = "Test",
                InitialPayload = 20,
                Coordinates = new Coordinates { X = 4, Y = 3 },
                ForecastedWeather = "Foggy"
            };

            var sut = new TestJsonCountryRepository();
            sut.Countries.Add(newCountry);

            // act
            sut.DeleteByName("lolloll");

            // assert
            Assert.Contains(newCountry, sut.Countries);
        }


    }

    public class TestJsonCountryRepository : JsonCountryRepository
    {
        public readonly List<CountryModel> Countries = new();
        // template pattern instead of moq
        public override List<CountryModel> LoadJson()
        {
            return Countries;
        }

        public override void WriteJson()
        {
            return;
        }
    }
}