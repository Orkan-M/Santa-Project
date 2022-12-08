using Santa_project.Data;
using Santa_Project.Models;
using System.Text.Json;

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
            const string fileName = @"../Santa-Project/Santa Project/Data/countries.json";
            var jsonString = File.ReadAllText(fileName);
            var allCountries = JsonSerializer.Deserialize<CountryModel[]>(jsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            return allCountries;
        }




        public CountryModel GetCountryById(int id)
        {
            if(id== null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _countries.FirstOrDefault(c => c.Id.Equals(id));
        }
    }
}