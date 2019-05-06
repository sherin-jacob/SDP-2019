using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NZTravel2.View;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NZTravel2
{
    public class ItineraryViewModel : BaseFodyObservable
    {
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
        private async Task<ILookup<string, Itinerary>> GetGroupedItinerary()
        {
            return (await App.ItineraryRepository.GetList())
                                .OrderBy(t => t.IsCompleted)
                                .ToLookup(t => t.IsCompleted ? "" : "Your Itinerary");
        }

        //TODO in sprint 2
        public Command StartItem { get; set; }
        public async void HandleStartItem(Itinerary item)
        {
        //    var location = new Location(this.lat, this.longi);
        //    var options = new MapLaunchOptions
        //    {
        //        Name = item.Title
        //    };
        //    await Map.OpenAsync(location, options);
        }

        // This function handles what happens when an item is deleted from the database
        public Command<Itinerary> Delete { get; set; }
        public async void HandleDelete(Itinerary itemToDelete)
        {
            await App.ItineraryRepository.DeleteItem(itemToDelete);//calls the delete function in the repository class

            // Update displayed list
            GroupedItinerary = await GetGroupedItinerary();
        }

        //This function handles what happens when an item is added to the database.
        public Command AddItem { get; set; }
        public async void HandleAddItem()
        {
            await _navigation.PushModalAsync(new AttractionRegionPage()); // Takes the user to the attractionregion page to choose a new item to add
        }

        //This function handles what happens when the edit button is clicked
        //TODO there's a bug in this function where it adds an extra item. This is because we weren't sure how to make the command a Task.
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

        public async Task RefreshTaskList()
        {
            GroupedItinerary = await GetGroupedItinerary(); // Refreshes the itinerary
        }

        public ILookup<string, Itinerary> GroupedItinerary { get; set; }
        public string Title => "Itinerary";
    }
}