﻿using System;
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
        public ItineraryViewModel(INavigation navigation,int j)
        {
            _navigation = navigation;
            GetGroupedItinerary().ContinueWith(t =>
            {
                GroupedItinerary = t.Result;
            });
            l = new ObservableCollection<Itinerary>();
            Delete = new Command<Itinerary>(HandleDelete);
            AddItem = new Command(HandleAddItem);
            EditItem = new Command<Itinerary>(HandleEditItem);
            //StartItem = new Command(HandleStartItem);
        }
        private INavigation _navigation;
        private async Task<ILookup<string, Itinerary>> GetGroupedItinerary()
        {
            List<Itinerary> k =await  App.ItineraryRepository.GetList();
            for(int i=0;i<k.Count;i++)
            {
                l.Add(k[i]);
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
        public Command<Itinerary> EditItem { get; set; }
        public async void HandleEditItem(Itinerary itemToEdit)
        {
            //Itinerary bedit = itemToEdit;
            //int count = await App.ItineraryRepository.countAsync();
            //int acount;
            //HandleDelete(itemToEdit);
            //    await _navigation.PushModalAsync(new AddItinerary(itemToEdit.Title));
            //    acount = await App.ItineraryRepository.countAsync();
            //Console.WriteLine(count+"!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!"+acount);
            //if (count != acount)
            //{
            //await App.ItineraryRepository.AddItem(itemToEdit);
            //HandleDelete(itemToEdit);
            //count = await App.ItineraryRepository.countAsync();
            //}
            //GroupedItinerary = await GetGroupedItinerary();
        for(int i=0;i<l.Count;i++)
            {
                Console.WriteLine(l[i].Title);
            }
        
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