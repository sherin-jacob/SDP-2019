using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using NZTravel2.View;
using SQLite;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NZTravel2
{
    public class ItineraryViewModel : BaseFodyObservable
    {
        int j;
        public ItineraryViewModel(INavigation navigation,int j)
        {
            _navigation = navigation;
            GetGroupedItinerary().ContinueWith(t =>
            {
                GroupedItinerary = t.Result;
            });
            this.j = j;
            l = new ObservableCollection<Itinerary>();
            Delete = new Command<Itinerary>(HandleDelete);
            AddItem = new Command(HandleAddItem);
            DetailsItem = new Command<Itinerary>(HandleDetailItem);
            //StartItem = new Command(HandleStartItem);
        }
        private INavigation _navigation;
        private async Task<ILookup<string, Itinerary>> GetGroupedItinerary()
        {
            l.Clear();
            List<Itinerary> k =await  App.ItineraryRepository.GetList();
            if (k.Count != 0)
            {
                for (int i = 0; i < k.Count; i++)
                {
                    if (k[i].ItineraryId == j)
                    {
                        l.Add(k[i]);
                    }
                }
            }
            return (await App.ItineraryRepository.GetList())
                                .ToLookup(t => t.IsCompleted ? "Completed" : "Your Itinerary");
                              
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
        public Command Delete { get; set; }
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
        public Command<Itinerary> DetailsItem { get; set; }
        public async void HandleDetailItem(Itinerary itemToView)
        {
           await _navigation.PushModalAsync(new ItineraryDetailPage(itemToView));
        }


        public async Task RefreshTaskList()
        {
            GroupedItinerary = await GetGroupedItinerary(); // Refreshes the itinerary
        }

        public ILookup<string, Itinerary> GroupedItinerary { get; set; }
        public string Title => "Itinerary";
        public ObservableCollection<Itinerary> l { get; set; }
    }
}