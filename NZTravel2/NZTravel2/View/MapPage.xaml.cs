using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public MapPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Display();
            //MapPageLayout();
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

    }
}