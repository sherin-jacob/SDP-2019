using Xamarin.Forms;
using NZTravel2.Persistence;
using System;

namespace NZTravel2

{
    public class AddItineraryViewModel : BaseFodyObservable
    {
        string placeName { get; set; }
        private INavigation _navigation;
        public TimeSpan SelectedTime { get; set; }
        public DateTime Date { get; set; }


        public AddItineraryViewModel(INavigation navigation, string PlaceName, TimeSpan time, DateTime date)
        {
            _navigation = navigation;
            placeName = PlaceName;
            SelectedTime = time;
            Date = date;
            Console.WriteLine("Date is " + date);
            Save = new Command(HandleSave);
            Cancel = new Command(HandleCancel);
        }

        //Saves the new item in the database
        public Command Save { get; set; }
        public async void HandleSave()
        {
            await App.ItineraryRepository.AddItem(new Itinerary { Title = placeName, time=SelectedTime, date = Date}); //this adds item to the database
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