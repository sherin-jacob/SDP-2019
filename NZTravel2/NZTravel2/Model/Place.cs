using System;
using System.Collections.Generic;
using System.Text;

namespace NZTravel2.Model
{
    public class Place
    {
        public string Name { get; set; }
        public string place_id { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public string vicinity { get; set; }
        public string formatted_address { get; set; }
        public Object opening_hours { get; set; }
        public double rating { get; set; }
        public string region { get; set; }
    }
}
