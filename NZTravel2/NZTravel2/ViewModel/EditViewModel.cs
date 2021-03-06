﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NZTravel2.ViewModel
{
    public class EditViewModel : BaseFodyObservable
    {
        private Itinerary oldi;
        public TimeSpan SelectedTime { get; set; }
        public DateTime Date { get; set; }
        public INavigation _navigation;
        public ILookup<string, Itinerary> GroupedItinerary { get; set; }

        public EditViewModel(INavigation navigation, TimeSpan t, DateTime d,Itinerary i)
        {
            oldi = i;
            SelectedTime = t;
            Date = d;
            GetGroupedItinerary().ContinueWith(ti =>
            {
                GroupedItinerary = ti.Result;
            });
            _navigation = navigation;
            Save = new Command(HandleSave);
            Cancel = new Command(HandleCancel);

        }

        //gets items in the Itinerary table as a list
        private async Task<ILookup<string, Itinerary>> GetGroupedItinerary()
        {
            return (await App.ItineraryRepository.GetList())
                                .ToLookup(ti => ti.IsCompleted ? "Completed" : "Your Itinerary");

        }

        //Saves the new item in the Itinerary table
        public Command Save { get; set; }
        public async void HandleSave()
        {
            await App.ItineraryRepository.DeleteItem(oldi);
            //this adds item to the database
            await App.ItineraryRepository.AddItem(new Itinerary { time = SelectedTime, date = Date,
                ItineraryId = oldi.ItineraryId, Title = oldi.Title }); 
            await _navigation.PopModalAsync();
        }

        //This function handles what happens when cancel is pressed when editing
        public Command Cancel{ get; set; }
        public async void HandleCancel()
        {
            await App.ItineraryRepository.DeleteItem(oldi);
            await App.ItineraryRepository.AddItem(oldi);
            await _navigation.PopModalAsync();
        }
    }
}
