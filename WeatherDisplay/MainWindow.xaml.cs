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



            //Display the temperature retrieved back from the API.
            GetWeatherDataResponse response = Utility.GetWeatherData(API_ENDPOINT).Result;

            //To convert meters per second to mph - multiply by 2.236936
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
