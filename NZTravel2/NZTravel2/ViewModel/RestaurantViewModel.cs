﻿using System;
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
    class RestaurantPageViewModel
    {
        private double lat, longi;
        private ObservableCollection<Place> PlaceList;
        public ObservableCollection<Place> placeList
        {
            get { return PlaceList; }
            set => PlaceList = value;
        }

        public RestaurantPageViewModel(double latitude, double longitude)
        {
            lat = latitude;
            longi = longitude;
            GetNearbyPlacesAsync();
        }

        //default constructor
        public RestaurantPageViewModel()
        {
            GetNearbyPlacesAsync();
        }

        //this function uses the current location to find places of type restaurant nearby
        async void GetNearbyPlacesAsync()
        {
            placeList = new ObservableCollection<Place>();
            RootObject rootObject = null;
            var client = new HttpClient();
            await RetrieveLocation();
            string latitude = lat.ToString();
            string longitude = longi.ToString();
            string restUrl = $"https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=" + latitude + "," 
                + longitude + "&type=restaurant&rankby=distance&key=AIzaSyDsihFkzPZuiJEVZd8tzrodeVe84ttZkRk";
            var uri = new Uri(restUrl);
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                rootObject = JsonConvert.DeserializeObject<RootObject>(content);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("No web response", 
                    "Unable to retrieve information, please try again", "OK");
            }
            //adds each result to the placeList for display purposes
            foreach (var item in rootObject.results)
            {
                placeList.Add(item);
            }
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

    }
}