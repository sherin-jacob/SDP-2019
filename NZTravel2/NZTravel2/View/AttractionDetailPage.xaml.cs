using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NZTravel2.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NZTravel2.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AttractionDetailPage : ContentPage
	{
		public AttractionDetailPage(Place place)
		{
			InitializeComponent ();

            GetDetails(place);

            Name.Text = place.Name;
            Address.Text = "Address: \n" + place.formatted_address;
            if (place.open_now) //this is not displaying correctly defaults to false
            {
                OpeningHours.Text = "Currently open!";
            }
            else
            {
                OpeningHours.Text = "Currently closed.";
            }
            Rating.Text = "Rating: " + place.rating.ToString() + "/5";


        }

        async void GetDetails(Place place)
        {
            var client = new HttpClient();
            string restUrl = $"https://maps.googleapis.com/maps/api/place/details/json?placeid=" + place.place_id + "&fields=formatted_phone_number,website&key=AIzaSyDsihFkzPZuiJEVZd8tzrodeVe84ttZkRk";
            var uri = new Uri(restUrl);
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var SelectedPlace = JsonConvert.DeserializeObject(content);
                //place.formatted_phone_number = SelectedPlace[1];
                Console.WriteLine("Done");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("No web response", "Unable to retrieve information, please try again", "OK");
            }
        }
	}
}