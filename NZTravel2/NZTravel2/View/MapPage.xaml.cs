using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using Plugin.Geolocator;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

namespace NZTravel2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public static double longitude;
        public static double latitude;
        public static int x = 0;

        public MapPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Display();
        }

        //this async function calls the RetrieveLocation function because it can't be called directly from the constructor
        async void Display()
        {
            await RetrieveLocation();
        }

        //this function retrieves the devices current location
        async Task RetrieveLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 20;
            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(120));

            //assigns values to global variables latitude and longitude
            longitude = position.Longitude;
            latitude = position.Latitude;

            //moves the map to the specified position
            map.MoveToRegion(
                MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude),
                Distance.FromMiles(0.5)));

            //adds a pin to the map with the Label 'Current Position'
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

        public int GetX()
        {
            return x;
        }

        //function that runs when the enter or search button is pressed
        public void OnSearchButtonPress(object sender, System.EventArgs e)
        {
            var text = SearchBar.Text; //gets text in the search bar
            GetPlace(text); //passes the text to the async function GetPlace
        }

        //async function used to call the ShowPlace function because can't be called directly from OnSearchButtonPress
        public async void GetPlace(string text)
        {
            await ShowPlace(text);
        }
        private void HomeButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new HomePage());
        }

        //shows results of what was searched in the map page
        public async Task ShowPlace(string text)
        {
            map.Pins.Clear(); //clears all pins on the map
            Geocoder gc = new Geocoder();
            IEnumerable<Position> result = await gc.GetPositionsForAddressAsync(text); //get all possible results for that text
            //go through each result returned and put a pin on that position
            //the map will be moved to the last position in the list
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
                x++;
            }
        }

        //for unit testing
        public int Math(int x)
        {
            if (x > 0)
            {
                return x;
            }
            return 5;
        }
    }
}
