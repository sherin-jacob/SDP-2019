using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZTravel2.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NZTravel2.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddNewItineraryPage : ContentPage
	{
		public AddNewItineraryPage ()
		{
			InitializeComponent ();
            Entry.Placeholder = "Hello";
            //string name = Entry.Text; //storing null
            BindingContext = new AddNewItineraryViewModel(Navigation, Entry.Placeholder);
		}
	}
}