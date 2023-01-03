using Santa_Project.Data.Country;
using Santa_Project.Models;
using System.Text.Json;

namespace Santa_Project.Data
{

    public class JsonCountryRepository : IJsonCountryRepository
    {
        private readonly List<CountryModel> _countries;
        const string fileName = @"..\Santa Project\Data\countries.json";
        public JsonCountryRepository()
        {
            _countries = LoadJson();
        }


        public virtual List<CountryModel> LoadJson()
        {
            var jsonString = File.ReadAllText(fileName);

            var allCountries = JsonSerializer.Deserialize<List<CountryModel>>(jsonString);
            return allCountries;
        }

        public virtual void WriteJson()
        {
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

            var country = _countries.FirstOrDefault(c => c.Name.Equals(name));
            if (country == null)
            {
                throw new ArgumentException("No country with that name currently Exists");
            }

            return country;
        }

        // need to add case checking
        public CountryModel AddCountry(CountryModel country)
        {
            if (country.Name == null || country.Coordinates == null || country.InitialPayload == null)
            {
                throw new ArgumentException(nameof(country));
            }
            var incomingCountryName = _countries.Find(c => c.Name.Equals(country.Name));
            var incomingCountryCoords = _countries.Find(
                c => c.Coordinates.X.Equals(country.Coordinates.X) &&
                     c.Coordinates.Y.Equals(country.Coordinates.Y));

            if (incomingCountryName != null || incomingCountryCoords != null)
            {
                throw new ArgumentException("A country already exists with that name or at the given coordinates");
            }

            //Check if Forecasted Weather is == "Foggy" else set to default of "Clear"
            if (country.ForecastedWeather != "Foggy")
            {
                country.ForecastedWeather = "Clear";
            }
            else
            {
                country.ForecastedWeather = "Foggy";
            }
            _countries.Add(country);
            WriteJson();
            return country;
            
        }

        // case checking
        public void DeleteByName(string name)
        {
            // remove from list
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            var countryToRemove = _countries.Find(c => c.Name.Equals(name));

            _countries.Remove(countryToRemove);
            var options = new JsonSerializerOptions { WriteIndented = true };

            // remove from json file
            WriteJson();
        }

        public uint GetCountryPayload(string name)
        {
            if (name == null)
            {
                throw new ArgumentException(nameof(name));
            }

            var country = _countries.Find(c => c.Name.Equals(name));

            //Casted to Uint
            return (uint)country.InitialPayload;
        }

        public CountryModel UpdatePayload(string name, uint payload)
        {
            if (name == null || payload == null)
            {
                throw new ArgumentException(nameof(name));
            }

            var country = _countries.Find(c => c.Name.Equals(name));

            country.InitialPayload = payload;

            //Call the method to write to the JSON file.
            WriteJson();
            return country;
        }
    }
}