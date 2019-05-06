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
	public partial class ItineraryDetailPage : ContentPage
	{
        //displays the name,time and date; TODO in Sprint 2: display in itinerary tab
		public ItineraryDetailPage (Itinerary itinerary)
		{
			InitializeComponent ();
            Name.Text = itinerary.Title;
            Time.Text = itinerary.time.ToString();
            Date.Text = itinerary.date.ToShortDateString();
		}
	}
}