using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherDisplay.WeatherData
{
    public class GetWeatherDataResponse
    {
        public List<string> Errors { get; set; }
        public WeatherBitData WeatherBitData { get; set; }
        public OpenWeatherData OpenWeatherData { get; set; }
    }
}
