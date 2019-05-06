using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NZTravel2.View;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using Plugin.Geolocator;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

namespace NZTravel2
{
    public class ItineraryViewModel : BaseFodyObservable
    {
         //Creates grouped itinerary; TODO in Sprint 2: Needs to be changed for future user stories
        public ItineraryViewModel(INavigation navigation)
        {
            _navigation = navigation;
            GetGroupedItinerary().ContinueWith(t =>
            {
                GroupedItinerary = t.Result;
            });
            Delete = new Command<Itinerary>(HandleDelete);
            AddItem = new Command(HandleAddItem);
            EditItem = new Command<Itinerary>(HandleEditItem);
            //StartItem = new Command(HandleStartItem);
        }
        private INavigation _navigation;

        //Adds items to grouped itinerary
        private async Task<ILookup<string, Itinerary>> GetGroupedItinerary()
        {
            return (await App.ItineraryRepository.GetList())
                                .OrderBy(t => t.IsCompleted)
                                .ToLookup(t => t.IsCompleted ? "" : "Your Itinerary");
        }


        //TODO in sprint 2
        public Command StartItem { get; set; }
        public async Task HandleStartItem(Itinerary item)
        {
         //   var address = item.fa;
          //  var locations = await Geocoding.GetLocationsAsync(address);
           // var location = locations?.FirstOrDefault();
           //var l = new Location(location.Longitude, location.Latitude);
           // var options = new MapLaunchOptions { Name = item.Title };
           // await Xamarin.Essentials.Map.OpenAsync(l, options);
        }


        //Deletes Item from Itinerary
        public Command<Itinerary> Delete { get; set; }
        public async void HandleDelete(Itinerary itemToDelete)
        {
            await App.ItineraryRepository.DeleteItem(itemToDelete);
            // Update displayed list
            GroupedItinerary = await GetGroupedItinerary();
        }

        //Adds item to Itinerary
        public Command AddItem { get; set; }
        public async void HandleAddItem()
        {
            await _navigation.PushModalAsync(new AttractionRegionPage());
        }


        //Edits item in itinerary
        public Command<Itinerary> EditItem { get; set; }
        public async void HandleEditItem(Itinerary itemToEdit)
        {
            Itinerary bedit= itemToEdit;
            int count = await App.ItineraryRepository.countAsync();
            HandleDelete(itemToEdit);
            await _navigation.PushModalAsync(new AddItinerary(itemToEdit.Title));
            int acount = await App.ItineraryRepository.countAsync();
            if(count != acount)
            {
                await App.ItineraryRepository.AddItem(bedit);
            }
            GroupedItinerary = await GetGroupedItinerary();
        }

        // Refreshes the itinerary
        public async Task RefreshTaskList()
        {
            GroupedItinerary = await GetGroupedItinerary(); 
        }

        public ILookup<string, Itinerary> GroupedItinerary { get; set; }
        public string Title => "Itinerary";
    }
}