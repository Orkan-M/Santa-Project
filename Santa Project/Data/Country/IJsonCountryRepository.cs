using Santa_Project.Models;

namespace Santa_Project.Data.Country
{

    public interface IJsonCountryRepository
    {

        public CountryModel GetCountryByName(string name);

        public CountryModel AddCountry(CountryModel country);

        public List<CountryModel> LoadJson();


    }














}