using Santa_Project.Models;

namespace Santa_project.Data
{

    public interface IJsonCountryRepository
    {

        public CountryModel GetCountryById(int id);

        public IEnumerable<CountryModel> LoadJson();


    }














}