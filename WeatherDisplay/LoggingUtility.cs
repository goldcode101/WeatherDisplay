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

            decimal F = Convert.ToDecimal(loggingData.TemperatureF);
            decimal dew = Convert.ToDecimal(loggingData.DewpointF);
            decimal wspd = Convert.ToDecimal(loggingData.WindSpeedMPH);

            string logMessage = $"Time:{loggingData.LogTime},City:{loggingData.LogCity},Type:{loggingData.LogType},TemperatureF:{Math.Round(F, 1)}," +
                $"WindSpeedMPH:{Math.Round(wspd, 1)},DewpointF:{Math.Round(dew, 1)}";

            using (StreamWriter writer = File.AppendText(logFilePath))
            {
                writer.WriteLine(logMessage);
            }

        }
    }
}
