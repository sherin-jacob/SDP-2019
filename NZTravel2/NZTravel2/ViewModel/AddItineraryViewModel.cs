using Xamarin.Forms;
using NZTravel2.Persistence;
using System;

namespace NZTravel2

{
    class AddItineraryViewModel : BaseFodyObservable
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

        public Command Save { get; set; }
        public async void HandleSave()
        {
            await App.ItineraryRepository.AddItem(new Itinerary { Title = placeName, time=SelectedTime, date = Date});
            await _navigation.PopModalAsync();
        }

        public Command Cancel { get; set; }
        public async void HandleCancel()
        {
            await _navigation.PopModalAsync();
        }
    }
}