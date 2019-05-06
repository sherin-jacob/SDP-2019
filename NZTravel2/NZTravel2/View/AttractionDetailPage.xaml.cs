using System;
using System.Net.Http;
using Newtonsoft.Json;
using NZTravel2.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials; 

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

            //GetDetails(place);

            Name.Text = place.Name;
            Address.Text = "Address: \n" + place.formatted_address;
            
            //if (place.open_now) //this is not displaying correctly defaults to false
            //{
            //    OpeningHours.Text = "Currently open!";
            //}
            //else
            //{
            //    OpeningHours.Text = "Currently closed.";
            //}
            Rating.Text = "Rating: " + place.rating.ToString() + "/5";

            this.longitude = place.lng;
            this.latitude = place.lat;
            this.place = place;
        }

        public AttractionDetailPage()
        {
            return;
        }

        async void GetDetails(Place place)
        {
            RootObjectDetails rootObject = null;
            var client = new HttpClient();
            string restUrl = $"https://maps.googleapis.com/maps/api/place/details/json?placeid=" + place.place_id + "&fields=formatted_phone_number,website&key=AIzaSyDsihFkzPZuiJEVZd8tzrodeVe84ttZkRk";
            var uri = new Uri(restUrl);
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                rootObject = JsonConvert.DeserializeObject<RootObjectDetails>(content);
                Console.WriteLine("Done");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("No web response", "Unable to retrieve information, please try again", "OK");
            }
        }

        private void MapViewButton_Clicked(object sender, EventArgs e)
        {
            //open google maps using xamarin.essentials
            var location = new Location(this.latitude, this.longitude);
            var options = new MapLaunchOptions
            {
                Name = this.place.Name
            };

            Map.OpenAsync(location, options);
        }

        private void AddtoItineraryButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AddItinerary(this.place.Name));
        }
    }
}