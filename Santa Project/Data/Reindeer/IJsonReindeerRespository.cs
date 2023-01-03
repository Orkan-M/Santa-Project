using Santa_Project.Models;

namespace Santa_Project.Data.Reindeer
{
    public interface IJsonReindeerRepository
    {
        public ReindeerModel GetReindeerByName(string name);

        public ReindeerModel AddReindeer (ReindeerModel reindeer);
        public void RemoveReindeer (string reindeerName);
        public ReindeerModel EditReindeer (ReindeerModel reindeer);
    }
}