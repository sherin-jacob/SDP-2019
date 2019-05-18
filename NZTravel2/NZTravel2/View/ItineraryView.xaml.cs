using NZTravel2.View;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Android.Widget.AdapterView;

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

        //Refreshes the Itinerary when an item is added
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await (BindingContext as ItineraryViewModel).RefreshTaskList(); 
        }

        // When an item is click, takes the user to another page which contains details of the itinerary
        async Task Itinerary_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var i = (Itinerary)e.Item;
            await Navigation.PushModalAsync(new ItineraryDetailPage(i));  
        }

        private void EditButtonClicked(object sender, EventArgs e)
        {
            var i = (Itinerary)e;

            Navigation.PushModalAsync(new EditItinerary(i.Title));
       }

        // Send user back to home page


        private void HomeButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new HomePage());
        }

     
    }
}