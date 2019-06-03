using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NZTravel2.Model;
using NZTravel2.View;
using Plugin.Geolocator;
using Xamarin.Forms;


namespace NZTravel2.ViewModel
{
    class RestaurantsPageViewModel
    {
        private double lat;
        private double longi;

        private ObservableCollection<Place> PlaceList;
        public ObservableCollection<Place> placeList
        {
            get
            {
                return PlaceList;
            }
            set => PlaceList = value;
        }

        public RestaurantsPageViewModel(double latitude, double longitude)
        {

            lat = longitude;
            longi = longitude;
            GetNearbyPlacesAsync();

        }

        public RestaurantsPageViewModel()
        {
            GetNearbyPlacesAsync();
        }

        //Finding restaurants in near the users current location
        async void GetNearbyPlacesAsync()
        {
            placeList = new ObservableCollection<Place>();
            RootObject rootObject = null;
            var client = new HttpClient();
            await RetrieveLocation();
            string latitude = lat.ToString();
            string longitude = longi.ToString();

            // need key for restaurant location
            // edit below to match restaurants
            string restUrl = $"https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=" + latitude + "," + longitude + "&type=laundry&rankby=distance&key=AIzaSyDsihFkzPZuiJEVZd8tzrodeVe84ttZkRk";
            var uri = new Uri(restUrl);
            var response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                rootObject = JsonConvert.DeserializeObject<RootObject>(content);
            }

            else
            {
                // An error occurs then a message is displayed on the home screen
                await Application.Current.MainPage.DisplayAlert("No web response", "Unable to retrieve information, please try again", "OK");
            }

            // Each result is added to the placeList to display 
            foreach (var item in rootObject.results)
            {
                placeList.Add(item);
            }
        }

        // get the current location of the device 
        async Task RetrieveLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 20;
            var position = await locator.GetPositionAsync();

            longi = position.Longitude;
            lat = position.Latitude;
        }

    }


}

