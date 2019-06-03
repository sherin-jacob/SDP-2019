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

        //for each region in NZ there is a button which when clicked opens page showing attractions in the selected region
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
        private void TasmanRegionButton_Clicked(object sender, EventArgs e)
        {
            string region = "Tasman";
            Navigation.PushModalAsync(new AttractionsPage(region));
        }
        private void NelsonRegionButton_Clicked(object sender, EventArgs e)
        {
            string region = "Nelson";
            Navigation.PushModalAsync(new AttractionsPage(region));
        }
        private void MarlboroughRegionButton_Clicked(object sender, EventArgs e)
        {
            string region = "Marlborough";
            Navigation.PushModalAsync(new AttractionsPage(region));

        }
        private void WestCoastRegionButton_Clicked(object sender, EventArgs e)
        {
            string region = "West Coast";
            Navigation.PushModalAsync(new AttractionsPage(region));
        }
        private void CanterburyRegionButton_Clicked(object sender, EventArgs e)
        {
            string region = "Canterbury";
            Navigation.PushModalAsync(new AttractionsPage(region));
        }
        private void OtagoRegionButton_Clicked(object sender, EventArgs e)
        {
            string region = "Otago";
            Navigation.PushModalAsync(new AttractionsPage(region));
        }
        private void SouthlandRegionButton_Clicked(object sender, EventArgs e)
        {
            string region = "Southland";
            Navigation.PushModalAsync(new AttractionsPage(region));
        }
    }
}