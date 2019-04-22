using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZTravel2.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NZTravel2.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AttractionDetailPage : ContentPage
	{
		public AttractionDetailPage(Place place)
		{
			InitializeComponent ();

            Name.Text = place.Name;
            Address.Text = place.formatted_address;
            OpeningHours.Text = place.open_now;
            Rating.Text = place.rating.ToString();
		}
	}
}