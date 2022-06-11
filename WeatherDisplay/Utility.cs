using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherDisplay.WeatherData;

namespace WeatherDisplay
{
    public static class Utility
    {
        //Make a function for converting temperature

        //Make a function for retrieving data from the API
        public static async Task<GetWeatherDataResponse> GetWeatherData(string url)
        {
            GetWeatherDataResponse getWeatherDataResponse = new GetWeatherDataResponse();
            WeatherBitData weatherBitData = new WeatherBitData();
            string responseString;
            try
            {

                using var client = new WebClient();
                responseString = client.DownloadString(url);

                //Deserialize the response string
                weatherBitData = JsonConvert.DeserializeObject<WeatherBitData>(responseString);

                getWeatherDataResponse.WeatherBitData = weatherBitData;
                getWeatherDataResponse.Errors = null;
            }
            catch(Exception ex)
            {
                return new GetWeatherDataResponse() { Errors = new List<string> { ex.Message } };
            }

            return new GetWeatherDataResponse();
        }
    }
}
