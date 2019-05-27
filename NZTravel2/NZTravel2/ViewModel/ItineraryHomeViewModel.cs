using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZTravel2.View;
using Xamarin.Forms;

namespace NZTravel2.ViewModel
{
    class ItineraryHomeViewModel : BaseFodyObservable
    {
        public ItineraryHomeViewModel(INavigation navigation)
        {
            _navigation = navigation;
            GetGroupedItinerary().ContinueWith(t =>
            {
                GroupedItinerary = t.Result;
            });
            AddItem = new Command(HandleAddItem);
        }
        private INavigation _navigation;
          
        private async Task<ILookup<string, ItineraryHome>> GetGroupedItinerary()
        {
            return (await App.ItineraryRepository.GetItineraries()) 
                                .OrderBy(t => t.IsCompleted)
                                .ToLookup(t => t.IsCompleted ? "" : "Your Itineraries");
        }

        public ILookup<string, ItineraryHome> GroupedItinerary { get; set; }
        public string Title => "Itinerary";

        public Command AddItem { get; set; }
        public async void HandleAddItem()
        {
           await _navigation.PushModalAsync(new AddNewItineraryPage()); //needs to make create itinerary popup/page
        }

        public async Task RefreshTaskList()
        {
            GroupedItinerary = await GetGroupedItinerary(); // Refreshes the itinerary
        }
    }
}
