using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NZTravel2.Model;
using Plugin.Geolocator;
using Xamarin.Forms;

namespace NZTravel2.ViewModel
{
    class AttractionsPageViewModel
    {
        private double lat, longi;
        private ObservableCollection<Place> PlaceList;
        public ObservableCollection<Place> placeList
        {
            get { return PlaceList; }
            set => PlaceList = value;
        }

        public AttractionsPageViewModel()
        {
            GetNearbyPlacesAsync();
        }

        async void GetNearbyPlacesAsync()
        {
            placeList = new ObservableCollection<Place>();
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
