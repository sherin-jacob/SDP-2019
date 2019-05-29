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
    public partial class FuelPage : ContentPage
    {
        public double longi { get; set; }
        public double lat { get; set; }
        public static object Location { get; set; }

        public FuelPage()
        {
            
            BindingContext = new FuelPageViewModel();
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

        //opens up the seleceted fuel station in the device's default Google Maps application
        async void FuelStations_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //var FuelStation = (Place)e.Item;
            //var address = FuelStation.vicinity;
            //var locations = await Geocoding.GetLocationsAsync(address);
            //var location = locations?.FirstOrDefault();
            //var options = new MapLaunchOptions
            //{
            //    Name = FuelStation.Name
            //};
            //await Map.OpenAsync(location, options);
            var FuelStation = (Place)e.Item;
            await Navigation.PushModalAsync(new AttractionDetailPage(FuelStation, "fuel"));
            FuelStations.SelectedItem = null;
        }

        //button links to the Home page
        private void HomeButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new HomePage());
        }
    }
}