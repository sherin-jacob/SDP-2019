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
        private string region;
        private ObservableCollection<Place> PlaceList;
        public ObservableCollection<Place> placeList
        {
            get { return PlaceList; }
            set => PlaceList = value;
        }

        public AttractionsPageViewModel(string region)
        {
            this.region = region;
            Display();    
        }

        async void Display()
        {
            await GetNearbyPlacesAsync();
        }

        async Task GetRegion()
        {
            RootObjectCity rootObject = null;
            var client = new HttpClient();
            await RetrieveLocation();
            string restUrl = $"https://maps.googleapis.com/maps/api/geocode/json?latlng=" + lat + "," + longi +"&key=AIzaSyDsihFkzPZuiJEVZd8tzrodeVe84ttZkRk";
            var uri = new Uri(restUrl);
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                rootObject = JsonConvert.DeserializeObject<RootObjectCity>(content);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("No web response", "Unable to retrieve information, please try again", "OK");
            }
            var regioninfo = rootObject.results.ToArray()[0];
            int index = 0;
            foreach (var item in regioninfo.address_components)
            {
                if (item.long_name == "New Zealand")
                {
                    break;
                }
                index++;
            }
            region = regioninfo.address_components[index-1].long_name;
        }

        async Task GetNearbyPlacesAsync()
        {
            placeList = new ObservableCollection<Place>();
            RootObject rootObject = null;
            //RootObject rootObject2 = null; //added
            var client = new HttpClient();
            if (region == "current")
            {
                await GetRegion();
            }
            string restUrl = $"https://maps.googleapis.com/maps/api/place/textsearch/json?query=attractions+in+" + region + "&key=AIzaSyDsihFkzPZuiJEVZd8tzrodeVe84ttZkRk";
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
                if (item.opening_hours != null)
                {
                    //somehow have to get the nested open now value here
                }
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
