using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace NZTravel2
{
    public class ItineraryHome : BaseFodyObservable
    {
        [PrimaryKey, AutoIncrement]
        public int ItineraryId { get; set; }
        public string Name { get; set; }
        public Boolean IsCompleted { get; set; }
    }
}
