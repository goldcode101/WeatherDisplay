using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherDisplay.WeatherData
{
    public class LoggingData
    {
        public string ObservedTime { get; set; }
        public string LogCity { get; set; }
        public DateTime LogTime { get; set; }
        public string LogType { get; set; }
        public string TemperatureF { get; set; }
        public string WindSpeedMPH { get; set; }
        public string DewpointF { get; set; }
    }
}
