using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NZTravel2.ViewModel
{
    class AddNewItineraryViewModel
    {
        private INavigation _navigation;
        Entry Itinerary { get; set; }

        public AddNewItineraryViewModel(INavigation navigation, Entry itinerary)
        {
            _navigation = navigation;
            Itinerary = itinerary;
            Save = new Command(HandleSave);
            Cancel = new Command(HandleCancel);
        }

        //Saves the new item in the ItineraryHome table
        public Command Save { get; set; }
        public async void HandleSave()
        {
            if (Itinerary.Text == null)
            {
                //this adds item to the ItineraryHome table
                await App.ItineraryRepository.AddItinerary(new ItineraryHome { Name = "New Itinerary" }); 
            }
            else if (Itinerary.Text.Length > 0)
            {
                await App.ItineraryRepository.AddItinerary(new ItineraryHome { Name = Itinerary.Text}); 

            }
            //this pops the most recent page created
            await _navigation.PopModalAsync(); 
        }

        //This function handles what happens when cancel is pressed when adding a new item
        public Command Cancel { get; set; }
        public async void HandleCancel()
        {
            await _navigation.PopModalAsync();
        }
    }
}
