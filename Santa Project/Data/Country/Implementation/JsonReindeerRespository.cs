// using Santa_Project.Data;
using Santa_Project.Models;
using System.Text.Json;

namespace Santa_Project.Data
{

    //public class JsonReindeerRepository : IJsonReindeerRepository
    //{
    //    private readonly IEnumerable<ReindeerModel> _reindeer;

    //    public JsonReindeerRepository()
    //    {
    //        _reindeer = LoadJson();
    //    }

    //    public virtual IEnumerable<ReindeerModel> LoadJson()
    //    {
    //        const string fileName = @"../Santa Project/Data/reindeer.json";
    //        var jsonString = File.ReadAllText(fileName);
    //        var allCountries = JsonSerializer.Deserialize<ReindeerModel[]>(jsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
    //        return allCountries;
    //    }

    //    public ReindeerModel GetReindeerByName(String name)
    //    {
    //        if (name == null)
    //        {
    //            throw new ArgumentNullException(nameof(name));
    //        }

    //        return _reindeer.FirstOrDefault(r => r.Name.Equals(name));
    //    }

    //    public void AddReindeer(ReindeerModel reindeer)
    //    {
    //        var newReindeer = new ReindeerModel
    //        {
    //            Name = reindeer.Name,
    //            Capacity = reindeer.Capacity,
    //            Range = reindeer.Range,
    //            ShinyNose = reindeer.ShinyNose ?? false,
    //        };
    //    }

    //    public void RemoveReindeer(ReindeerModel reindeer)
    //    {
    //        var reindeerToRemove = _reindeer.Where(r => r.Name.Equals(reindeer.Name)).ToList();
    //        _reindeer.Remove(reindeerToRemove);
    //    }

    //    public void EditReindeer(ReindeerModel reindeer)
    //    {
    //        var reindeerToEdit = _reindeer.Where(r => r.Id == reindeer.Id).ToList();
    //        _reindeer.Find(r => r.Name == reindeer.Name).Name == reindeer.Name
    //        var reindeerID = reindeer.Id;
    //        var editedReindeer = new ReindeerModel
    //        {
    //            Id = reindeerID,
    //            Name = reindeer.Name,
    //            Capacity = reindeer.Capacity,
    //            Range = reindeer.Range,
    //            ShinyNose = reindeer.ShinyNose,
    //        };
    //    }
    //}
}