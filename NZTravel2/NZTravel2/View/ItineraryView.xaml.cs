using NZTravel2.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NZTravel2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItineraryView : ContentPage
    {
        public ItineraryView()
        {
            InitializeComponent();
            BindingContext = new ItineraryViewModel(Navigation);
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await (BindingContext as ItineraryViewModel).RefreshTaskList(); //Refreshes the Itinerary when an item is added
        }
        async void Itinerary_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var i = (Itinerary)e.Item;
            await Navigation.PushModalAsync(new ItineraryDetailPage(i));  // When an item is click, takes the user to another page which contains details of the itinerary
        }
        private void HomeButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new HomePage()); // When home is clicked, takes user back to home page
        }
    }
}