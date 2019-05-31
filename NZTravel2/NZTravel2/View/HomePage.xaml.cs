using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NZTravel2.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
		}

        //button links to the map page and displays an alert letting the user know they need to have the location services on for it to work
        void MapButtonClicked(object sender, EventArgs e)
        {
            DisplayAlert("Location Services", "Location Services must be turned on to view your current location", "OK");
            Navigation.PushModalAsync(new MapPage());
        }

        //button links to the fuel page
        private void FuelButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new FuelPage());
        }

        //button links to the attraction region page
        private void AttractionButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AttractionRegionPage());
        }

        //button links to the itinerary page
        private void ItineraryButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ItineraryHomeView());
        }
        private void RestaurantButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new RestaurantsPage());
        }
    }
}