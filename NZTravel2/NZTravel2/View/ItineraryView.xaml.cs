using NZTravel2.View;
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
            await (BindingContext as ItineraryViewModel).RefreshTaskList();
        }

        private void ViewDetails_Clicked(object sender, System.EventArgs e)
        {

            //Navigation.PushModalAsync(new AttractionDetailPage());
        }

        private void Journey_Clicked(object sender, System.EventArgs e)
        {

        }
    }
}