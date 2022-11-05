using System;
using System.Collections.Generic;
using System.Text;
using WeatherDisplay.WeatherData;

namespace WeatherDisplay
{
    public class FetchingUtility
    {
        public static string TimeStamp { get; set; }
        public static double TempF { get; set; }
        public static double TempC { get; set; }
        public static double MPH { get; set; }
        public static double DewF { get; set; }
        public static string CityInfo { get; set; }
        public static string Pressure { get; set; }
        public static GetWeatherDataResponse GetWeatherData(string endpoint)
        {
            GetWeatherDataResponse response = Utility.GetWeatherData(endpoint).Result;

            TimeStamp = ConvertToLocalTime(response.WeatherBitData.data[0].ob_time);
            TempF = Utility.ConvertCToF(double.Parse(response.WeatherBitData.data[0].temp));
            TempC = double.Parse(response.WeatherBitData.data[0].temp);
            MPH = Utility.ConvertMPS_To_MPH(double.Parse(response.WeatherBitData.data[0].wind_spd));
            DewF = Utility.ConvertCToF(double.Parse(response.WeatherBitData.data[0].dewpt));
            Pressure = response.WeatherBitData.data[0].pres;
            CityInfo = $"{response.WeatherBitData.data[0].city_name}_{response.WeatherBitData.data[0].state_code}_{response.WeatherBitData.data[0].country_code}";

            return response;
        }

        private static string ConvertToLocalTime(string time)
        {
            bool successfulConversion = DateTime.TryParse(time, out DateTime dt);

            return successfulConversion ? dt.ToLocalTime().ToString() : "";
        }
    }
}
