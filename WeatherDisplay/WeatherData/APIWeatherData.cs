using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherDisplay.WeatherData
{
    public class WeatherBitData
    {
        public List<WBData> data { get; set; }
        public string count { get; set; }
    }

    public class WBData
    {
        public string temp { get; set; }
        public string dewpt { get; set; }
        public string wind_spd { get; set; }
    }

    public class OpenWeatherData
    {
        public string TempC { get; set; }
    }
}
