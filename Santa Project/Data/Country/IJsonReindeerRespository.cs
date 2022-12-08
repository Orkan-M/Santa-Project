using Santa_Project.Models;

namespace Santa_Project.Data
{
    public interface IJsonReindeerRespository
    {
        public ReindeerModel GetReindeerByName(String name);

        public IEnumerable<ReindeerModel> LoadJson();
    }
}