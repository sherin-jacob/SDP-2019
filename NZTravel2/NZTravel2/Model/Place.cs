using System;
using System.Collections.Generic;
using System.Text;

namespace NZTravel2.Model
{
    class Place
    {
        public string Name { get; set; }
        public string place_id { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public string vicinity { get; set; }
        public string formatted_address { get; set; }
    }
}
