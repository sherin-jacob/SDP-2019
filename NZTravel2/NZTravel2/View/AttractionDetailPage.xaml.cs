using System;
using System.Net.Http;
using Newtonsoft.Json;
using NZTravel2.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace NZTravel2.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AttractionDetailPage : ContentPage
	{
        private double longitude;
        private double latitude;
        private Place place;
       
        public static object options { get; set; }
        public static object location { get; set; }

        public AttractionDetailPage(Place place)
		{
			InitializeComponent ();
            //function call to run the await statement
            Display(place);
            Name.Text = place.Name;
            Address.Text = "Address: \n" + place.formatted_address;
            if (place.opening_hours.open_now) 
            {
                OpenNow.Text = "Currently open!";
            }
            else
            {
                OpenNow.Text = "Currently closed.";
            }
            Rating.Text = "Rating: " + place.rating.ToString() + "/5";
            this.longitude = place.lng;
            this.latitude = place.lat;
            this.place = place;
        }

        //constructor called when restaurant or fuel details need to be viewed 
        public AttractionDetailPage(Place place, String fuel)
        {
            InitializeComponent();
            Display(place);
            Name.Text = place.Name;
            Address.Text = "Address: \n" + place.vicinity;
            if (place.opening_hours == null || place.opening_hours.open_now == true)
            {
                OpenNow.Text = "Currently open!";
            }
            else
            {
                OpenNow.Text = "Currently closed.";
            }
            Rating.Text = "";
            this.longitude = place.lng;
            this.latitude = place.lat;
            this.place = place;
        }

        //default constructor
        public AttractionDetailPage()
        {
            return;
        }

        //async function that runs the await statement
        public async void Display(Place place)
        {
            await GetDetails(place);
        }

        //get details of a place based on the place id by calling the Places API
        async Task GetDetails(Place place)
        {
            RootObjectDetails rootObject = null;
            var client = new HttpClient();
            string restUrl = $"https://maps.googleapis.com/maps/api/place/details/json?placeid=" + place.place_id 
                + "&fields=formatted_phone_number,website,photos&key=AIzaSyDsihFkzPZuiJEVZd8tzrodeVe84ttZkRk";
            var uri = new Uri(restUrl);
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                rootObject = JsonConvert.DeserializeObject<RootObjectDetails>(content);
                Website.Text = rootObject.result.website;
                Phone.Text = rootObject.result.formatted_phone_number;
                //gets photoId from Json results and passes the Id to the relevant function
                string photoID = rootObject.result.photos[0].photo_reference;
                await GetPhoto(photoID);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("No web response", 
                    "Unable to retrieve information, please try again", "OK");
            }
        }

        //get photo of a place by calling the Places API using the photo id
        async Task GetPhoto(string id)
        {
            var client = new HttpClient();
            string restUrl = $"https://maps.googleapis.com/maps/api/place/photo?maxwidth=400&photoreference=" 
                + id + "&key=AIzaSyDsihFkzPZuiJEVZd8tzrodeVe84ttZkRk";
            var uri = new Uri(restUrl);
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                Stream stream = await client.GetStreamAsync(uri);
                AttractionImage.Source = ImageSource.FromStream(() => stream);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("No web response", 
                    "Unable to retrieve information, please try again", "OK");
            }
        }

        //opens the place in the device's map application
        async void MapViewButton_Clicked(object sender, EventArgs e)
        {
            //open google maps using xamarin.essentials
            string address;
            if (this.place.formatted_address != null)
            {
                address = this.place.formatted_address;
            }
            else
            {
                address = this.place.vicinity;
            }
            var locations = await Geocoding.GetLocationsAsync(address);
            var location = locations?.FirstOrDefault();
            var options = new MapLaunchOptions
            {
                Name = this.place.Name
            };
            Location location1 = new Location(location.Latitude, location.Longitude);
            await Map.OpenAsync(location1, options);
        }

        //adds the place to the app's itinerary/database
        private void AddtoItineraryButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AddItinerary(this.place.Name));
        }
    }
}