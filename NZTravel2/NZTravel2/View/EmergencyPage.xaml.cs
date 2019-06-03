using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Messaging;
using Plugin.Geolocator;
using Xamarin.Essentials;

namespace NZTravel2.View
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmergencyPage : ContentPage
    {

        public EmergencyPage()
        {
            InitializeComponent();
            RetrieveLocation();
        }

        //gets the current location of the user and displays it as a label
        async Task RetrieveLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 20;
            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(120));
            //assigns values to global variables latitude and longitude
            var longitude = position.Longitude;
            var latitude = position.Latitude;
            //reverse geocode
            var placemarks = await Geocoding.GetPlacemarksAsync(latitude, longitude);
            var placemark = placemarks?.FirstOrDefault();
            if (placemark != null)
            {
                var geocodeAddress =
                    $"Current Location: {placemark.SubThoroughfare} " +
                    $"{placemark.Thoroughfare}\n" +
                    $"{placemark.SubLocality}\n" +
                    $"{placemark.Locality}\n" +
                    $"{placemark.AdminArea} " +
                    $"{placemark.PostalCode}\n" +
                    $"Latitude: {latitude.ToString()}\n" +
                    $"Longitude: {longitude.ToString()}\n";
                CurrentLocation.Text = geocodeAddress;
            }
        }

        //for each button clicked, a different number is dialed in the device's phone application
        private void TrafficButton_Clicked(object sender, EventArgs e)
        {
            var phoneDialer = CrossMessaging.Current.PhoneDialer;
            if (phoneDialer.CanMakePhoneCall)
                phoneDialer.MakePhoneCall("*555");
        }
        private void Ambulance_Clicked(object sender, EventArgs e)
        {
            var phoneDialer = CrossMessaging.Current.PhoneDialer;
            if (phoneDialer.CanMakePhoneCall)
                phoneDialer.MakePhoneCall("111");
        }
        private void AAButton_Clicked(object sender, EventArgs e)
        {
            var phoneDialer = CrossMessaging.Current.PhoneDialer;
            if (phoneDialer.CanMakePhoneCall)
                phoneDialer.MakePhoneCall("0800500222");
        }

        //button links to the Home page
        private void HomeButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new HomePage());
        }
    }
}