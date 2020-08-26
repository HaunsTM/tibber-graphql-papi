using System;
using System.Collections.Generic;
using System.Text;

namespace Client.RO
{
    public class Price
    {
        public double total { get; set; }
        public double energy { get; set; }
        public double tax { get; set; }
        public DateTime startsAt { get; set; }
        public string currency { get; set; }
        public string level { get; set; }

    }
}
