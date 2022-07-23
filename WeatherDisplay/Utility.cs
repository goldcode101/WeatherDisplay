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
        public static double ConvertCToF(double tempC)
        {
            //Multiply by 1.8 and add 32
            return tempC * 1.8 + 32;
        }

        public static double ConvertMPS_To_MPH(double metersPerSecond)
        {
            //To convert meters per second to mph - multiply by 2.236936
            return metersPerSecond * 2.236936;
        }

        //Make a function for retrieving data from the API
        public static async Task<GetWeatherDataResponse> GetWeatherData(string url)
        {
            GetWeatherDataResponse getWeatherDataResponse = new GetWeatherDataResponse();
            string responseString;

            try
            {

                using var client = new WebClient();
                responseString = client.DownloadString(url);

                //Deserialize the response string
                WeatherBitData weatherBitData = JsonConvert.DeserializeObject<WeatherBitData>(responseString);

                getWeatherDataResponse.WeatherBitData = weatherBitData;
                getWeatherDataResponse.Errors = null;
            }
            catch(Exception ex)
            {
                return new GetWeatherDataResponse() { Errors = new List<string> { ex.Message } };
            }

            return getWeatherDataResponse;
        }
    }
}
