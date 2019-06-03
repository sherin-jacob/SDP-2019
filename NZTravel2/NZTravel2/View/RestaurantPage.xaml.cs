using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NZTravel2.Model;
using NZTravel2.ViewModel;
using Plugin.Geolocator;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NZTravel2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestaurantPage : ContentPage
    {
        public double longi { get; set; }
        public double lat { get; set; }
        public static object Location { get; set; }

        public RestaurantPage()
        {
            BindingContext = new RestaurantPageViewModel();
            InitializeComponent();
        }

        async void Display()
        {
            await RetrieveLocation();
        }

        //gets the current location of the device
        async Task RetrieveLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 20;
            var position = await locator.GetPositionAsync();

            longi = position.Longitude;
            lat = position.Latitude;
        }

        //opens up the seleceted resturant in the device's default Google Maps application
        async void Restaurants_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var Restaurant = (Place)e.Item;
            var address = Restaurant.vicinity;
            var locations = await Geocoding.GetLocationsAsync(address);
            var location = locations?.FirstOrDefault();
            var options = new MapLaunchOptions
            {
                Name = Restaurant.Name
            };
            await Map.OpenAsync(location, options);
        }

        //button links to the Home page
        private void HomeButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new HomePage());
        }
    }
}