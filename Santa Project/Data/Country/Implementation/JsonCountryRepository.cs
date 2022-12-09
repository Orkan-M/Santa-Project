using System.Data.Common;
using Santa_Project.Data.Country;
using Santa_Project.Models;
using System.Text.Json;
using System.Xml.XPath;
using static Santa_Project.Models.CountryModel;

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
            const string fileName = @"C:\Users\TerryMills\source\repos\Santa-Project\Santa Project\Data\countries.json";
            var jsonString = File.ReadAllText(fileName);

            var allCountries = JsonSerializer.Deserialize<CountryModel[]>(jsonString);
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
                ForecastedWeather = country.ForecastedWeather,
                InitialPayload = country.InitialPayload,
                //Coordinates = country.Coordinates 
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