using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NZTravel2.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItineraryDetailPage : ContentPage
	{
        public Itinerary ItineraryToDetail { get; set; }

        //displays the name,time and date
		public ItineraryDetailPage (Itinerary itinerary)
		{
			InitializeComponent ();
            Name.Text = itinerary.Title;
            Time.Text = itinerary.time.ToString();
            Date.Text = itinerary.date.ToShortDateString();
            ItineraryToDetail = itinerary;
		}

        //opens location selected in Google Maps 
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var address = ItineraryToDetail.Title;
            var locations = await Geocoding.GetLocationsAsync(address);
            var location = locations?.FirstOrDefault();
            var options = new MapLaunchOptions
            {
                Name = ItineraryToDetail.Title
            };
            Location location1 = new Location(location.Latitude, location.Longitude);
            await Map.OpenAsync(location1, options);
        }
    }
}