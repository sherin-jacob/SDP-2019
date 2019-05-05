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
        private void NorthlandRegionButton_Clicked(object sender, EventArgs e)
        {
            string region = "Northland";
            Navigation.PushModalAsync(new AttractionsPage(region));
        }
        private void AucklandRegionButton_Clicked(object sender, EventArgs e)
        {
            string region = "Auckland";
            Navigation.PushModalAsync(new AttractionsPage(region));
        }
        private void WaikatoRegionButton_Clicked(object sender, EventArgs e)
        {
            string region = "Waikato";
            Navigation.PushModalAsync(new AttractionsPage(region));
        }
        private void BayOfPlentyRegionButton_Clicked(object sender, EventArgs e)
        {
            string region = "Bay of Plenty";
            Navigation.PushModalAsync(new AttractionsPage(region));
        }
        private void GisbourneRegionButton_Clicked(object sender, EventArgs e)
        {
            string region = "Gisbourne";
            Navigation.PushModalAsync(new AttractionsPage(region));
        }
        private void HawkesBayRegionButton_Clicked(object sender, EventArgs e)
        {
            string region = "Hawke's Bay";
            Navigation.PushModalAsync(new AttractionsPage(region));
        }
        private void TaranakiRegionButton_Clicked(object sender, EventArgs e)
        {
            string region = "Taranaki";
            Navigation.PushModalAsync(new AttractionsPage(region));
        }
        private void ManawatuRegionButton_Clicked(object sender, EventArgs e)
        {
            string region = "Manawatu-Wanganui";
            Navigation.PushModalAsync(new AttractionsPage(region));
        }
        private void WellingtonRegionButton_Clicked(object sender, EventArgs e)
        {
            string region = "Wellington";
            Navigation.PushModalAsync(new AttractionsPage(region));
        }
        private void HomeButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new HomePage());
        }
    }
}