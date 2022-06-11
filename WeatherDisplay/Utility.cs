﻿using System;
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
            APIWeatherData aPIWeatherData = new APIWeatherData();
            string responseString;
            try
            {
                //using (var client = new HttpClient())
                //{
                //    var response = await client.GetAsync(url);
                //    if (response.IsSuccessStatusCode)
                //    {
                //        responseString = await response.Content.ReadAsStringAsync();
                //    }
                //}

                /*
                using var client = new HttpClient();
                //var response = await client.GetAsync(url);
                var strResponse = await client.GetStringAsync(url);
                */

                using var client = new WebClient();
                responseString = client.DownloadString(url);

                //Deserialize the response string
            }
            catch(Exception ex)
            {
                return new GetWeatherDataResponse() { Errors = new List<string> { ex.Message } };
            }

            return new GetWeatherDataResponse();
        }
    }
}
