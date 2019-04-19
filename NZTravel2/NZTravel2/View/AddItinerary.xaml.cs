using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NZTravel2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddItinerary : ContentPage
    {
        public AddItinerary()
        {
            InitializeComponent();
            BindingContext = new AddItineraryViewModel(Navigation);
        }
    }
}