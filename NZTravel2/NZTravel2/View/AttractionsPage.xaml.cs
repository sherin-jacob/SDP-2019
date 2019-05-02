using NZTravel2.Model;
using NZTravel2.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NZTravel2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AttractionsPage : ContentPage
    {
        public AttractionsPage(string region)
        {
            InitializeComponent();
            if (region == "current")
            {
                CurrentRegion.Text = "Attractions in your Current Region";
            }
            else
            {
                CurrentRegion.Text = "Attractions in " + region;
            }
            
            BindingContext = new AttractionsPageViewModel(region);
        }

        async void Attractions_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var attraction = (Place)e.Item;
            await Navigation.PushAsync(new AttractionDetailPage(attraction));
            Attractions.SelectedItem = null;
        }
    }
}