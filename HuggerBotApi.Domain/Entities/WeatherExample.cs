using System.Collections.Generic;

namespace HuggerBotApi.Domain.Entities
{
    public class Coord
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }

    public class Weather
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class Main
    {
        private double feels;
        private double min;
        private double max;
        private double temp;
        public double Temp { get { return temp; } set { temp = value - 273.15; } }
        public double Feels_like { get { return feels; } set { feels = value - 273.15; } }
        public double Temp_min { get { return min; } set { min = value - 273.15; } }
        public double Temp_max { get { return max; } set { max = value - 273.15; } }
        public int Pressure { get; set; }
        public int Humidity { get; set; }

    }

    public class Wind
    {
        public int Speed { get; set; }
        public int Deg { get; set; }
    }

    public class Clouds
    {
        public int All { get; set; }
    }

    public class Sys
    {
        public int Type { get; set; }
        public int Id { get; set; }
        public string Country { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
    }

    public class WeatherExample
    {
        public Coord Coord { get; set; }
        public IList<Weather> Weather { get; set; }
        public string Base { get; set; }
        public Main Main { get; set; }
        public int Visibility { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public int Dt { get; set; }
        public Sys Sys { get; set; }
        public int Timezone { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
    }
}
