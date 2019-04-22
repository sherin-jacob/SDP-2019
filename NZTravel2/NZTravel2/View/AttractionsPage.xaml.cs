using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NZTravel2.Model;
using NZTravel2.ViewModel;
using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NZTravel2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AttractionsPage : ContentPage
    {
        public AttractionsPage()
        {
            InitializeComponent();
            BindingContext = new AttractionsPageViewModel();
        }
    }
}