﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace NZTravel2
{
    public class Itinerary : BaseFodyObservable
    {
        [PrimaryKey, AutoIncrement] // sets the primary key as the ID of the item
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public TimeSpan time { get; set; }
        public DateTime date { get; set; }

        [ForeignKey(typeof(ItineraryHome))]
        public int ItineraryId { get; set; } //foreign key to the ItineraryHome table

        public static explicit operator Itinerary(EventArgs v)
        {
            throw new NotImplementedException();
        }
    }
}
