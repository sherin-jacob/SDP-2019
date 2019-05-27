using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NZTravel2.ViewModel
{
    class AddNewItineraryViewModel
    {
        string ItineraryName { get; set; }
        private INavigation _navigation;

        public AddNewItineraryViewModel(INavigation navigation, string name)
        {
            _navigation = navigation;
            ItineraryName = name;
            Save = new Command(HandleSave);
            Cancel = new Command(HandleCancel);
        }

        //Saves the new item in the database
        public Command Save { get; set; }
        public async void HandleSave()
        {
            await App.ItineraryRepository.AddItinerary(new ItineraryHome { Name = ItineraryName }); //this adds item to the database
            await _navigation.PopModalAsync(); // this pops the most recent page created
        }

        //This function handles what happens when cancel is pressed when adding a new item
        public Command Cancel { get; set; }
        public async void HandleCancel()
        {
            await _navigation.PopModalAsync();
        }
    }
}
