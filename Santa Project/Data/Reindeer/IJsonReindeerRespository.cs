using Santa_Project.Models.Reindeer;

namespace Santa_Project.Data.Reindeer
{
    public interface IJsonReindeerRespository
    {
        public ReindeerModel GetReindeerByName(string name);

        public IEnumerable<ReindeerModel> LoadJson();
    }
}