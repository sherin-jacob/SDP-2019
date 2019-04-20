using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NZTravel2.Model;
using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NZTravel2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AttractionsPage : ContentPage
    {
        private double lat, longi;
        ObservableCollection<Place> placeList = new ObservableCollection<Place>();

        public AttractionsPage()
        {
            InitializeComponent();
            GetNearbyPlacesAsync();
        }

        async void GetNearbyPlacesAsync()
        {
            RootObject rootObject = null;
            var client = new HttpClient();
            await RetrieveLocation();
            string restUrl = $"https://maps.googleapis.com/maps/api/place/textsearch/json?query=attractions+in+Auckland&key=AIzaSyDsihFkzPZuiJEVZd8tzrodeVe84ttZkRk";
            var uri = new Uri(restUrl);
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                rootObject = JsonConvert.DeserializeObject<RootObject>(content);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("No web response", "Unable to retrieve information, please try again", "OK");
            }
            foreach (var item in rootObject.results)
            {
                placeList.Add(item);
            }
            Attractions.ItemsSource = placeList;
        }

        async Task RetrieveLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 20;
            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(120));

            longi = position.Longitude;
            lat = position.Latitude;
        }
    }
}