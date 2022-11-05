using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using WeatherDisplay;
using WeatherDisplay.WeatherData;
using WeatherLogger.Models;

namespace WeatherLogger
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly WorkerOptions options;

        public Worker(ILogger<Worker> logger, WorkerOptions options)
        {
            _logger = logger;
            this.options = options;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                string apiKey = options.Api_Key;
                string city = options.City;
                string API_ENDPOINT = $"https://api.weatherbit.io/v2.0/current?key={apiKey}&city={city}";

                var response = FetchingUtility.GetWeatherData(API_ENDPOINT);
                LoggingData lData = new LoggingData();

                lData.ObservedTime = FetchingUtility.TimeStamp;
                lData.LogTime = DateTime.Now;
                lData.LogCity = FetchingUtility.CityInfo;
                lData.LogType = "API-Log";
                lData.TemperatureF = FetchingUtility.TempF.ToString();
                lData.WindSpeedMPH = FetchingUtility.MPH.ToString();
                lData.DewpointF = FetchingUtility.DewF.ToString();

                WeatherDisplay.LoggingUtility.LogInfo(lData);
                await Task.Delay(options.LoggingDelay, stoppingToken);
            }
        }
    }
}
