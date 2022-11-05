using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherLogger.Models
{
    public class WorkerOptions
    {
        public int LoggingDelay { get; set; }
        public string Api_Key { get; set; }
        public string City { get; set; }
    }
}
