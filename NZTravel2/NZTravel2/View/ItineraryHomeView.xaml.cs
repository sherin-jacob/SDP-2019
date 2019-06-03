using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZTravel2.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NZTravel2.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItineraryHomeView : ContentPage
	{
		public ItineraryHomeView ()
		{
			InitializeComponent ();
            BindingContext = new ItineraryHomeViewModel(Navigation);
        }

        //updated itinerary is displayed when page is opened
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //Refreshes the Itinerary when an item is added
            await (BindingContext as ItineraryHomeViewModel).RefreshTaskList(); 
        }

        //opens page to show items in the selected itinerary
        async void Itinerary_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var i = (ItineraryHome)e.Item;
            await Navigation.PushModalAsync(new ItineraryView(i.ItineraryId)); 
        }

        //button links to the home page
        private void HomeButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new HomePage()); // When home is clicked, takes user back to home page
        }
    }
}