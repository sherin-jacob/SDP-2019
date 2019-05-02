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

        //public async Task ShowPlace(string text)
        //{
        //    RootObject rootObject = null;
        //    var client = new HttpClient();
        //    CultureInfo In = new CultureInfo("en-IN");
        //    string restUrl = $"https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=" + latitude + "," + longitude + "&radius=1000&keyword=" + text + "&key=AIzaSyDsihFkzPZuiJEVZd8tzrodeVe84ttZkRk";
        //    var uri = new Uri(restUrl);
        //    var response = await client.GetAsync(uri);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var content = await response.Content.ReadAsStringAsync();
        //        rootObject = JsonConvert.DeserializeObject<RootObject>(content);
        //        double latitude = 0, longitude = 0;
        //        foreach (Place place in rootObject.results)
        //        {
        //            map.Pins.Add(new Pin
        //            {
        //                Type = PinType.Place,
        //                Label = place.Name,
        //                Position = new Position(place.Latitude, place.Longitude)
        //            });
        //            latitude = place.Latitude;
        //            longitude = place.Longitude;
        //        }
        //        map.MoveToRegion(
        //            MapSpan.FromCenterAndRadius(new Position(latitude, longitude),
        //            Distance.FromMiles(0.5)));
        //    }
        //    else
        //    {
        //        await Application.Current.MainPage.DisplayAlert("No web response", "Unable to retrieve information, please try again", "OK");
        //    }
        //}