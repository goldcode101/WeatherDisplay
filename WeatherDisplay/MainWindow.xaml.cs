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
            string city = "Greenwood,IN";

            //OpenWeatherMap
            string appId = "ffa46403179998b01f9f70c7f681aa86";
            string cityId = "4259418";
            string API_ENDPOINT = $"https://api.weatherbit.io/v2.0/current?key={apiKey}&city={city}";

            string OPENWEATHER_API_ENDPOINT = $"http://api.openweathermap.org/data/2.5/weather?id={cityId}&appid={appId}";



            
            GetWeatherDataResponse response = Utility.GetWeatherData(API_ENDPOINT).Result;

            
            //Display the temperature retrieved back from the API.
            double tempF;
            try
            {
                tempF = Utility.ConvertCToF(double.Parse(response.WeatherBitData.data[0].temp));
                txtTempF.Text = Math.Round(tempF, 1).ToString() + " F";
            }
            catch(Exception ex)
            {
                txtTempF.Text = "ERR";
            }

            
            double dewptF;
            try
            {
                dewptF = Utility.ConvertCToF(double.Parse(response.WeatherBitData.data[0].dewpt));
                txtDew.Text = "Dewpoint: " + Math.Round(dewptF, 1).ToString() + " F";
            }
            catch(Exception ex)
            {
                txtDew.Text = "Dewpoint ERR";
            }

            double mph;
            try
            {
                mph = Utility.ConvertMPS_To_MPH(double.Parse(response.WeatherBitData.data[0].wind_spd));
                txtWindSpeed.Text = "Wind Speed (mph): " + Math.Round(mph, 1).ToString();
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
            
        }

        private void btnFTemp_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
