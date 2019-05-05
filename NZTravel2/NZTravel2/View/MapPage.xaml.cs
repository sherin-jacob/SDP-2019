using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using Plugin.Geolocator;

namespace NZTravel2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public static double longitude;
        public static double latitude;

        public MapPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Display();
        }

        async void Display()
        {
            await RetrieveLocation();
        }

        async Task RetrieveLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 20;
            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(120));

            longitude = position.Longitude;
            Longitude();
            latitude = position.Latitude;


            map.MoveToRegion(
                MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude),
                Distance.FromMiles(0.5)));

            map.Pins.Add(new Pin
            {
                Type = PinType.Place,
                Label = "Current Position",
                Position = new Position(position.Latitude, position.Longitude)
            });

        }

        public double Longitude()
        {
            return longitude;
        }

        public double Latitude()
        {
            return latitude;
        }

        public void OnSearchButtonPress(object sender, System.EventArgs e)
        {
            var text = SearchBar.Text;
            GetPlace(text);
        }

        public async void GetPlace(string text)
        {
            await ShowPlace(text);
        }
        private void HomeButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new HomePage());
        }
        public async Task ShowPlace(string text)
        {
            map.Pins.Clear();
            Geocoder gc = new Geocoder();
            IEnumerable<Position> result = await gc.GetPositionsForAddressAsync(text);
            foreach (Position pos in result)
            {
                map.Pins.Add(new Pin
                {
                    Type = PinType.Place,
                    Label = text,
                    Position = new Position(pos.Latitude, pos.Longitude)
                });
                map.MoveToRegion(
                    MapSpan.FromCenterAndRadius(new Position(pos.Latitude, pos.Longitude),
                    Distance.FromMiles(0.5)));
            }
        }
    }
}
