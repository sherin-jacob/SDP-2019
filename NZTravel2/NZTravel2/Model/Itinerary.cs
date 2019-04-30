using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace NZTravel2
{
    public class Itinerary : BaseFodyObservable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
