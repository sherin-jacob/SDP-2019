using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
            ShareItinerary = new Command(HandleShare);
        }
        private INavigation _navigation;
        private async Task<ILookup<string, Itinerary>> GetGroupedItinerary()
        {
            return (await App.ItineraryRepository.GetList())
                                .OrderBy(t => t.IsCompleted)
                                .ToLookup(t => t.IsCompleted ? "" : "Your Itinerary");
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

        public Command ShareItinerary { get; set; }
        public async void HandleShare()
        {
            var Itinerary = await GetGroupedItinerary();
            string ItineraryString = "Itinerary\r\n";
            foreach (var item in Itinerary)
            {
                if (Itinerary.Count() == 0)
                {
                    ItineraryString = "Nothing in the itinerary";
                    break;
                }
                foreach (Itinerary values in item)
                {
                    string newString = "\r\nName: " + values.Title + "\r\nTime: " + values.time + "\r\nDate: " + values.date.ToShortDateString() + "\r\n";
                    ItineraryString += newString;
                }
            }
            var Fn = "Itinerary.txt";
            var file = Path.Combine(FileSystem.CacheDirectory, Fn);
            File.WriteAllText(file, ItineraryString);
            await Share.RequestAsync(new ShareFileRequest
            {
                File = new ShareFile(file)
            });
        }

        public ILookup<string, Itinerary> GroupedItinerary { get; set; }
        public string Title => "Itinerary";
    }
}