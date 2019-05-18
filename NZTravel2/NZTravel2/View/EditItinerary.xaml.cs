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
	public partial class EditItinerary : ContentPage
	{
        public EditItinerary(string name)
        {
            InitializeComponent();
            Entry.Placeholder = name;
            //send name, time and date to add to database
            BindingContext = new AddItineraryViewModel(Navigation, name, _timePicker.Time, datePicker.Date);
        }
    }
}