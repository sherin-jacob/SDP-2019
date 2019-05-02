using System;
using System.Collections.Generic;
using System.Text;

namespace NZTravel2.Model
{
    class Address
    {
        public string long_name { get; set; }
        public List<Address> address_components { get; set; }

    }
}
