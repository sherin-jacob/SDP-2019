using NZTravel2.Model;
using NZTravel2.ViewModel;
using System;
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
            //display the text of the label depending on the region selected
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

        //links to the detail page of the attraction selected
        async void Attractions_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var attraction = (Place)e.Item;
            await Navigation.PushModalAsync(new AttractionDetailPage(attraction));
            Attractions.SelectedItem = null;
        }
    }
}