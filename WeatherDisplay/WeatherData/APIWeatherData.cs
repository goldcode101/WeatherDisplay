using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherDisplay.WeatherData
{
    public class WeatherBitData
    {
        public List<WBData> data { get; set; }
        public string count { get; set; }
    }

    public class WBData
    {
        public string temp { get; set; }        //Temperature(C)
        public string dewpt { get; set; }       //Dewpoint
        public string wind_spd { get; set; }    //Wind speed
        public string rh { get; set; }          //Relative humidity
        public string pod { get; set; }         //Part of day
        public string pres { get; set; }        //Pressure(mb)
        public string timezone { get; set; }    
        public string ob_time { get; set; }     //Observation time(UTC)
        public string country_code { get; set; }
        public string clouds { get; set; }
        public string ts { get; set; }
        public string solar_rad { get; set; }   //Solar radiation
        public string state_code { get; set; }
        public string city_name { get; set; }
        public string wind_cdir_full { get; set; }
        public string wind_cdir { get; set; }
        public string slp { get; set; }
        public string vis { get; set; }
        public string h_angle { get; set; }
        public string sunset { get; set; }
        public string dni { get; set; }
        public string snow { get; set; }
        public string uv { get; set; }
        public string precip { get; set; }
        public string wind_dir { get; set; }
        public string sunrise { get; set; }
        public string ghi { get; set; }
        public string dhi { get; set; }
        public string aqi { get; set; }
        public Weather weather { get; set; }
        public string datetime { get; set; }
        public string station { get; set; }
        public string elev_angle { get; set; }
        public string app_temp { get; set; }

    }

    public class Weather
    {
        public string icon { get; set; }
        public string code { get; set; }
        public string description { get; set; }
    }

    public class OpenWeatherData
    {
        public string TempC { get; set; }
    }
}
