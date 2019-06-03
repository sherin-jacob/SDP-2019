using System;
using System.Collections.Generic;
using System.Text;

namespace NZTravel2.Model
{
    public class PlaceDetails
    {
        public string website { get; set; }
        public string formatted_phone_number { get; set; }
        public Photo[] photos {get;set;}
    }
}
