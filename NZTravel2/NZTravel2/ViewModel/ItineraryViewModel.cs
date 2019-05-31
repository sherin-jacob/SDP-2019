using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NZTravel2.View;
using SQLite;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NZTravel2
{
    public class ItineraryViewModel : BaseFodyObservable
    {
        int j;
        public ItineraryViewModel(INavigation navigation, int j)
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
            ShareItinerary = new Command(HandleShare);
        }
        private INavigation _navigation;
        private async Task<ILookup<string, Itinerary>> GetGroupedItinerary()
        {
            l.Clear();
            List<Itinerary> k = await App.ItineraryRepository.GetList();
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