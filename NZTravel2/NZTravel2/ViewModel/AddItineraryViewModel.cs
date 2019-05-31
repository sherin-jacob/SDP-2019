using Xamarin.Forms;
using NZTravel2.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Linq;

namespace NZTravel2

{
    public class AddItineraryViewModel : BaseFodyObservable
    {
        string placeName { get; set; }
        private INavigation _navigation;
        public TimeSpan SelectedTime { get; set; }
        public DateTime Date { get; set; }
        public ObservableCollection<string> ll { get; set; }
        public ILookup<string, Itinerary> GroupedItinerary { get; set; }
        public List<ItineraryHome> k;
        public Object si { get; set; }
        public AddItineraryViewModel(INavigation navigation, string PlaceName, TimeSpan time, DateTime date)
        {
            _navigation = navigation;
            GetGroupedItinerary().ContinueWith(t =>
            {
                GroupedItinerary = t.Result;
            });
            ll = new ObservableCollection<string>();
            placeName = PlaceName;
            SelectedTime = time;
            Date = date;
            Save = new Command(HandleSave);
            Cancel = new Command(HandleCancel);
        }

        private async Task<ILookup<string, Itinerary>> GetGroupedItinerary()
        {
             k = await App.ItineraryRepository.GetItineraries();
             for(int i=0;i<k.Count;i++)
            {
                ll.Add(k[i].Name);
            }
            return (await App.ItineraryRepository.GetList())
                                .ToLookup(t => t.IsCompleted ? "Completed" : "Your Itinerary");

        }
        //Saves the new item in the database
        public Command Save { get; set; }
        public async void HandleSave()
        {
            for(int i=0;i<ll.Count;i++)
            {

                if(ll[i].Equals(si.ToString()))
                {
                    await App.ItineraryRepository.AddItem(new Itinerary { Title = placeName, time = SelectedTime, date = Date, ItineraryId=k[i].ItineraryId }); //this adds item to the database
                }
            }
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