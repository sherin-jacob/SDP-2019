using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
using NZTravel2.Model;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace NZTravel2.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FuelPage : ContentPage
	{
		public FuelPage ()
		{
			InitializeComponent ();
            GetNearbyPlacesAsync();
        }

        public async void GetNearbyPlacesAsync()
        {
            RootObject rootObject = null;
            var client = new HttpClient();
            CultureInfo In = new CultureInfo("en-IN");
            string latitude = "-36.8532";
            string longitude = "174.767";
            string restUrl = $"https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=" + latitude + "," + longitude + "&radius=1000&type=restaurant&key=AIzaSyDsihFkzPZuiJEVZd8tzrodeVe84ttZkRk";
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
            Console.WriteLine("HELLO");
            //return rootObject.results;
        }
    }
}