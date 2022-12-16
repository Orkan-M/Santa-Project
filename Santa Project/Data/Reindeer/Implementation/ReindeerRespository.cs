// using Santa_Project.Data;

using System.Runtime.InteropServices.ComTypes;
using Santa_Project.Models;
using System.Text.Json;
using Santa_Project.Models.Reindeer;
using Microsoft.AspNetCore.Components.RenderTree;

namespace Santa_Project.Data.Reindeer
{
    public interface IReindeerProvider
    {
        List<ReindeerModel> LoadJson();
        void WriteJson(List<ReindeerModel> reindeer);
    }

    public class JsonReindeerProvider : IReindeerProvider
    {
        public List<ReindeerModel> LoadJson() => JsonSerializer.Deserialize<List<ReindeerModel>>(@"..\Santa-Project\Santa Project\Data\countries.json");

        public void WriteJson(List<ReindeerModel> reindeer) => File.WriteAllText(@"..\Santa-Project\Santa Project\Data\countries.json", JsonSerializer.Serialize(reindeer, new JsonSerializerOptions { WriteIndented = true }));
    }

    public class ReindeerRepository : IReindeerRepository
    {
        private readonly IReindeerProvider _reindeerProvider;

        private readonly List<ReindeerModel> _reindeer;

        public ReindeerRepository(IReindeerProvider reindeerProvider)
        {
            _reindeerProvider = reindeerProvider;
            _reindeer = _reindeerProvider.LoadJson();
        }
        
        public ReindeerModel GetReindeerByName(string name)
        {
            var find = _reindeerProvider.LoadJson().FirstOrDefault(r => r.Name == name);

            if (find == null)
            {
                throw new ArgumentException(nameof(name));
            }

            return find;
        }

        public ReindeerModel AddReindeer(ReindeerModel reindeerToAdd)
        {
            var incomingReindeer = _reindeerProvider.LoadJson().Find(r => r.Name == reindeerToAdd.Name);

            if (incomingReindeer == null)
            {
                _reindeer.Add(reindeerToAdd);
                _reindeerProvider.WriteJson(_reindeer);
                return reindeerToAdd;
            }

            throw new ArgumentException(nameof(reindeerToAdd), "A Reindeer with that name already exists");
        }

        public void RemoveReindeer(string reindeerName)
        {
            // remove from list
            var reindeerToRemove = _reindeer.Find(r => r.Name.Equals(reindeerName));
            if (reindeerToRemove != null)
            {
                _reindeer.Remove(reindeerToRemove);

                _reindeerProvider.WriteJson(_reindeer);

            }
            else
            {
                throw new ArgumentException("No reindeer with that name to remove");
            }
            
        }

        public ReindeerModel EditReindeer(ReindeerModel reindeer)
        {
            var reindeerToEdit = _reindeer.Find(r => r.Name == reindeer.Name);

            if (reindeerToEdit != null)
            {
                _reindeer.Remove(reindeerToEdit);
                _reindeer.Add(reindeer);

                _reindeerProvider.WriteJson(_reindeer);
                return reindeer;
            }

            throw new ArgumentException(nameof(reindeer), "Could not find the given Reindeer to edit");
        }
    }

}