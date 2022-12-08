using Santa_Project.Data;
using Santa_Project.Data.Country;
using Santa_Project.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Santa_Project.Data
{

    public class JsonCountryRepository : IJsonCountryRepository
    {
        private readonly IEnumerable<CountryModel> _countries;

        public JsonCountryRepository()
        {
            _countries = LoadJson();
        }

        public virtual IEnumerable<CountryModel> LoadJson()
        {
            const string fileName = @"C:\Users\OrkanMustafa\Source\Repos\Orkssss\Santa-Project\Santa Project\Data\countries.json";
            var jsonString = File.ReadAllText(fileName);
            var allCountries = JsonSerializer.Deserialize<CountryModel[]>(jsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            return allCountries;
        }


        public CountryModel GetCountryByName(string name)
        {
            if(name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            return _countries.FirstOrDefault(c => c.Name.Equals(name));
        }



        public void AddCountry(CountryModel country)
        {
            var newCountry = new CountryModel
            {
                Name = country.Name,
                XCoordinate = country.XCoordinate,
                YCoordinate = country.YCoordinate,
                ForecastedWeather = country.ForecastedWeather,
                InitialPayload = country.InitialPayload
            };
            
        }
       
        public void RemoveCountry(CountryModel country)
        {
            // remove from list
            var countryToRemove = _countries.Where(c => c.Name.Equals(country.Name)).First();
            _countries.ToList().Remove(countryToRemove);

            // remove from json file
            const string fileName = @"../Santa Project/Data/countries.json";
            string jsonString = JsonSerializer.Serialize(_countries);
            File.WriteAllText(fileName, jsonString);
        }
    }
}