using System.Data.Common;
using Santa_Project.Data.Country;
using Santa_Project.Models;
using System.Text.Json;
using System.Xml.XPath;
using System.Linq;
using static Santa_Project.Models.CountryModel;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace Santa_Project.Data
{

    public class JsonCountryRepository : IJsonCountryRepository
    {
        private readonly List<CountryModel> _countries;

        public JsonCountryRepository()
        {
            _countries = LoadJson();
        }


        public virtual List<CountryModel> LoadJson()
        {
            //const string fileName = @"C:\Users\TerryMills\source\repos\Santa-Project\Santa Project\Data\countries.json";
            const string fileName = @"..\Santa Project\Data\countries.json";

            var jsonString = File.ReadAllText(fileName);

            var allCountries = JsonSerializer.Deserialize<List<CountryModel>>(jsonString);
            return allCountries;
        }

        public void WriteJson()
        {
            const string fileName = @"C:\Users\TerryMills\source\repos\Santa-Project\Santa Project\Data\countries.json";

            var options = new JsonSerializerOptions { WriteIndented = true };

            string countrySerialize = JsonSerializer.Serialize(_countries, options);

            File.WriteAllText(fileName, countrySerialize);

        }


        public CountryModel GetCountryByName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            return _countries.FirstOrDefault(c => c.Name.Equals(name));
        }



        public CountryModel AddCountry(CountryModel country)
        {
            var incomingCountry = _countries.Where(c => c.Name.Equals(country.Name) &&
                                                        c.Coordinates.X.Equals(country.Coordinates.X)
                                                        && c.Coordinates.Y.Equals(country.Coordinates.Y));

            if (incomingCountry.Any() == false)
            {
                var newCountry = new CountryModel
                {
                    Name = country.Name,
                    ForecastedWeather = country.ForecastedWeather,
                    InitialPayload = country.InitialPayload,
                    Coordinates = country.Coordinates
                };
                _countries.Add(newCountry);
                WriteJson();
                return newCountry;
                //write to file
            }
            else
            {
                throw new ArgumentException("Invalid country");
            }


        }

        public void DeleteByName(string name)
        {
            // remove from list
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            var countryToRemove = _countries.Where(c => c.Name.Equals(name)).First();
           
            _countries.Remove(countryToRemove);
            var options = new JsonSerializerOptions { WriteIndented = true };

            // remove from json file
            const string fileName = @"../Santa Project/Data/countries.json";
            string jsonString = JsonSerializer.Serialize(_countries, options);
            File.WriteAllText(fileName, jsonString);
        }

        public int GetCountryPayload(string name)
        {
            if (name == null)
            {
                throw new ArgumentException(nameof(name));
            }

            var country = _countries.Where(c => c.Name.Equals(name)).First();

            return country.InitialPayload;
        }
    }
}