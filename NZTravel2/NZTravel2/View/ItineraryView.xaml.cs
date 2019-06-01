using NZTravel2.View;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace NZTravel2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItineraryView : ContentPage
    {
        int j;
        public ItineraryView(int j)
        {
            InitializeComponent();
            this.j = j;
            BindingContext = new ItineraryViewModel(Navigation, j);
        }

        //Refreshes the Itinerary when an item is added
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await (BindingContext as ItineraryViewModel).RefreshTaskList();
        }

        // When an item is click, takes the user to another page which contains details of the itinerary
        //async void Itinerary_ItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    var i = (Itinerary)e.Item;
        //    i.ItineraryId = j;
        //    await Navigation.PushModalAsync(new ItineraryDetailPage(i));  
        //}
        async void Itinerary_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var i = (Itinerary)e.Item;
            i.ItineraryId = j;
            await Navigation.PushModalAsync(new ItineraryDetailPage(i));
        }
        // Send user back to home page


        private void HomeButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new HomePage()); // When home is clicked, takes user back to home page
        }


    }
}