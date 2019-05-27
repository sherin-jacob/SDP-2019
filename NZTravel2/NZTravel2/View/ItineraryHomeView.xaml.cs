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

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await (BindingContext as ItineraryHomeViewModel).RefreshTaskList(); //Refreshes the Itinerary when an item is added
        }

        async void Itinerary_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //var i = (Itinerary)e.Item;
            await Navigation.PushModalAsync(new ItineraryView());  //need to change itinerary view class file so that it displays what you clicked
        }

        private void HomeButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new HomePage()); // When home is clicked, takes user back to home page
        }
    }
}