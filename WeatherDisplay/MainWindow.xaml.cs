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
            string city = "Indianapolis,IN";

            //OpenWeatherMap
            string appId = "ffa46403179998b01f9f70c7f681aa86";
            string cityId = "4259418";
            string API_ENDPOINT = $"https://api.weatherbit.io/v2.0/current?key={apiKey}&city={city}";

            string OPENWEATHER_API_ENDPOINT = $"http://api.openweathermap.org/data/2.5/weather?id={cityId}&appid={appId}";

            //Get the weather data and store it on the class.
            var response = FetchingUtility.GetWeatherData(API_ENDPOINT);

            DoLogging();

            DisplayWeatherData(response);
        }

        public void DoLogging()
        {
            LoggingData loggingData = new LoggingData();

            loggingData.ObservedTime = FetchingUtility.TimeStamp;
            loggingData.LogTime = DateTime.Now;
            loggingData.LogCity = FetchingUtility.CityInfo;
            loggingData.LogType = "API-Log";
            loggingData.TemperatureF = FetchingUtility.TempF.ToString();
            loggingData.WindSpeedMPH = FetchingUtility.MPH.ToString();
            loggingData.DewpointF = FetchingUtility.DewF.ToString();

            LoggingUtility.LogInfo(loggingData);
        }

        public void DisplayWeatherData(GetWeatherDataResponse response)
        {
            try
            {
                txtObservedTime.Text = $"Observed Time: {FetchingUtility.TimeStamp}";
            }
            catch (Exception ex) { }

            //Display the temperature retrieved back from the API.
            try
            {
                txtTemp.Text = Math.Round(FetchingUtility.TempF, 1).ToString() + " F";
            }
            catch (Exception ex)
            {
                txtTemp.Text = "ERR";
            }

            try
            {
                txtDew.Text = "Dewpoint: " + Math.Round(FetchingUtility.DewF, 1).ToString() + " F";
            }
            catch (Exception ex)
            {
                txtDew.Text = "Dewpoint ERR";
            }

            try
            {
                txtWindSpeed.Text = "Wind Speed (mph): " + Math.Round(FetchingUtility.MPH, 1).ToString();
            }
            catch (Exception ex)
            {
                txtWindSpeed.Text = "Wind Speed ERR";
            }

            try
            {
                txtPressure.Text = "Pressure: " + FetchingUtility.Pressure + "mb";
            }
            catch (Exception ex) { }

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
            txtTemp.Text = Math.Round(FetchingUtility.TempC, 1).ToString() + " C";
        }

        private void btnFTemp_Click(object sender, RoutedEventArgs e)
        {
            //Convert the temperature to F and then display it.
            txtTemp.Text = Math.Round(FetchingUtility.TempF, 1).ToString() + " F";
        }
    }
}
