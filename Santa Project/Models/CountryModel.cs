namespace Santa_Project.Models
{
    public class CountryModel
    {
        public string Name { get; set; }
        public int XCoordinate {get; set;} // ?? Min-max: -20 to 20
        public int YCoordinate {get; set;} // ?id Coordinates { get; set; }
        public string ForecastedWeather { get; set; }
        public int InitialPayload { get; set; }
    }
}
