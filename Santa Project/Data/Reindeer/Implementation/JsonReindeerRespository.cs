// using Santa_Project.Data;
using Santa_Project.Models;
using System.Text.Json;

namespace Santa_Project.Data.Reindeer
{
    public class JsonReindeerRepository : IJsonReindeerRepository
    {
        private readonly List<ReindeerModel> _reindeer;
        const string fileName = @"..\Santa Project\Data\reindeer.json";

        public JsonReindeerRepository()
        {
            _reindeer = LoadJson();
        }


        public virtual List<ReindeerModel> LoadJson()
        {
            var jsonString = File.ReadAllText(fileName);
            var allReindeer = JsonSerializer.Deserialize<List<ReindeerModel>>(jsonString);
            return allReindeer;
        }

        public void WriteJson()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string countrySerialize = JsonSerializer.Serialize(_reindeer, options);
            File.WriteAllText(fileName, countrySerialize);
        }


        public ReindeerModel GetReindeerByName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            return _reindeer.FirstOrDefault(r => r.Name.Equals(name));
        }



        public ReindeerModel AddReindeer(ReindeerModel reindeer)
        {
            var incomingReindeer = _reindeer.Find(r => r.Name == reindeer.Name);

            if (incomingReindeer == null)
            {
                var newReindeer = new ReindeerModel
                {
                    Name = reindeer.Name,
                    Capacity = reindeer.Capacity,
                    Range = reindeer.Range,
                    ShinyNose = reindeer.ShinyNose
                };
                _reindeer.Add(newReindeer);
                WriteJson();
                return newReindeer;
            }
            throw new ArgumentException(nameof(reindeer), "A Reindeer with that name already exists");
        }

        public void RemoveReindeer(string reindeerName)
        {
            var reindeerToRemove = _reindeer.Find(r => r.Name.Equals(reindeerName));
            _reindeer.Remove(reindeerToRemove);

            WriteJson();
        }

        public ReindeerModel EditReindeer(ReindeerModel reindeer)
        {
            var reindeerToEdit = _reindeer.Find(r => r.Name == reindeer.Name);

            if (reindeerToEdit != null)
            {
                reindeerToEdit.Name = reindeer.Name;
                reindeerToEdit.Capacity = reindeer.Capacity;
                reindeerToEdit.ShinyNose = reindeer.ShinyNose;
                reindeerToEdit.Range = reindeer.Range;

                WriteJson();
                return reindeerToEdit;
            }

            throw new ArgumentException(nameof(reindeer), "Could not find the given Reindeer to edit");
        }
    }

}