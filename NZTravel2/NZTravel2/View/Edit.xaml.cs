using NZTravel2.ViewModel;
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
	public partial class Edit : ContentPage
	{
		public Edit (Itinerary i)
		{
			InitializeComponent ();
            BindingContext = new EditViewModel(Navigation, _timePicker.Time, datePicker.Date,i);
        }
	}
}