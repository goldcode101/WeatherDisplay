using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WeatherDisplay.WeatherData;

namespace WeatherDisplay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double TempF { get; set; }
        public double TempC { get; set; }
        public double MPH { get; set; }
        public double DewF { get; set; }
        public string CityInfo { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            //Set up the application
            this.Title = "WeatherDisplay";
            this.ResizeMode = ResizeMode.NoResize;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Topmost = false;
            this.WindowState = WindowState.Normal;

            //Call into a method to get the data from the API.
            //Weatherbit.io
            string apiKey = "e16d19d7d9d64ae29a53de24c6f6a73f";
            string city = "Greenwood,IN";

            //OpenWeatherMap
            string appId = "ffa46403179998b01f9f70c7f681aa86";
            string cityId = "4259418";
            string API_ENDPOINT = $"https://api.weatherbit.io/v2.0/current?key={apiKey}&city={city}";

            string OPENWEATHER_API_ENDPOINT = $"http://api.openweathermap.org/data/2.5/weather?id={cityId}&appid={appId}";



            
            GetWeatherDataResponse response = Utility.GetWeatherData(API_ENDPOINT).Result;
            TempF = Utility.ConvertCToF(double.Parse(response.WeatherBitData.data[0].temp));
            TempC = double.Parse(response.WeatherBitData.data[0].temp);
            MPH = Utility.ConvertMPS_To_MPH(double.Parse(response.WeatherBitData.data[0].wind_spd));
            DewF = Utility.ConvertCToF(double.Parse(response.WeatherBitData.data[0].dewpt));
            CityInfo = $"{response.WeatherBitData.data[0].city_name}_{response.WeatherBitData.data[0].state_code}_{response.WeatherBitData.data[0].country_code}";

            //Do logging
            LoggingData loggingData = new LoggingData();
            loggingData.LogTime = DateTime.Now;
            loggingData.LogCity = CityInfo;
            loggingData.LogType = "API-Log";
            loggingData.TemperatureF = TempF.ToString();
            loggingData.WindSpeedMPH = MPH.ToString();
            loggingData.DewpointF = DewF.ToString();
            LoggingUtility.LogInfo(loggingData);
            
            //Display the temperature retrieved back from the API.
            try
            {
                txtTemp.Text = Math.Round(TempF, 1).ToString() + " F";
            }
            catch(Exception ex)
            {
                txtTemp.Text = "ERR";
            }

            
            try
            {
                txtDew.Text = "Dewpoint: " + Math.Round(DewF, 1).ToString() + " F";
            }
            catch(Exception ex)
            {
                txtDew.Text = "Dewpoint ERR";
            }

            try
            {
                txtWindSpeed.Text = "Wind Speed (mph): " + Math.Round(MPH, 1).ToString();
            }
            catch(Exception ex)
            {
                txtWindSpeed.Text = "Wind Speed ERR";
            }

            txtCity.Text = response.WeatherBitData.data[0].city_name;
            txtState.Text = response.WeatherBitData.data[0].state_code;
            txtCountry.Text = response.WeatherBitData.data[0].country_code;

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCTemp_Click(object sender, RoutedEventArgs e)
        {
            //Convert the temperature to C and then display it.
            txtTemp.Text = Math.Round(TempC, 1).ToString() + " C";
        }

        private void btnFTemp_Click(object sender, RoutedEventArgs e)
        {
            //Convert the temperature to F and then display it.
            txtTemp.Text = Math.Round(TempF, 1).ToString() + " F";
        }
    }
}
