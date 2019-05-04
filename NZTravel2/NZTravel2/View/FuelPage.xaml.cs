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

        public FuelPage()
        {
            InitializeComponent();
            BindingContext = new FuelPageViewModel();
        }

        async void Display()
        {
            await RetrieveLocation();
        }

        async Task RetrieveLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 20;
            var position = await locator.GetPositionAsync();

            longi = position.Longitude;
            lat = position.Latitude;
        }

        async void FuelStations_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //await RetrieveLocation();
            var FuelStation = (Place)e.Item;
            var location = new Location(this.lat, this.longi);
            var options = new MapLaunchOptions
            {
                Name = FuelStation.Name
            };
            await Map.OpenAsync(location, options);
        }
    }
}