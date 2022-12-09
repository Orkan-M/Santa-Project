using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Santa_Project.Models
{
    public class CountryModel
    {
        public string Name { get; set; }
        public string ForecastedWeather { get; set; }
        public int InitialPayload { get; set; }
        public Coordinates Coordinates { get; set; }

    }
    public class Coordinates
    {
        [Range(-20,20)]
        public int X { get; set; }
        [Range(-20, 20)]
        public int Y { get; set; }
    }
}
