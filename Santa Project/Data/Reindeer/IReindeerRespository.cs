using Santa_Project.Models.Reindeer;

namespace Santa_Project.Data.Reindeer
{
    public interface IReindeerRepository
    {
        public ReindeerModel GetReindeerByName(string name);

        public ReindeerModel AddReindeer (ReindeerModel reindeer);
        public void RemoveReindeer (string reindeerName);
        public ReindeerModel EditReindeer (ReindeerModel reindeer);
    }
}