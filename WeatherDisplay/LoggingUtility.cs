using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WeatherDisplay.WeatherData;

namespace WeatherDisplay
{
    public class LoggingUtility
    {
        public static void LogInfo(LoggingData loggingData)
        {
            string logFilePath = @"C:\Logs\WeatherDisplay\WeatherDisplayLog.txt";

            string logMessage = $"Time:{loggingData.LogTime},City:{loggingData.LogCity},Type:{loggingData.LogType},TemperatureF:{loggingData.TemperatureF}," +
                $"WindSpeedMPH:{loggingData.WindSpeedMPH},DewpointF:{loggingData.DewpointF}";

            using (StreamWriter writer = File.AppendText(logFilePath))
            {
                writer.WriteLine(logMessage);
            }

        }
    }
}
