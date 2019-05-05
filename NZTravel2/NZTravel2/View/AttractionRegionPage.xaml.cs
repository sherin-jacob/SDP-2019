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
    public partial class AttractionRegionPage : ContentPage
    {
        public AttractionRegionPage()
        {
            InitializeComponent();
        }

        private void CurrentRegionButton_Clicked(object sender, EventArgs e)
        {
            string region = "current";
            Navigation.PushModalAsync(new AttractionsPage(region));
        }

        private void WaikatoRegionButton_Clicked(object sender, EventArgs e)
        {
            string region = "Waikato";
            Navigation.PushModalAsync(new AttractionsPage(region));
        }
        private void HomeButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new HomePage());
        }
    }
}