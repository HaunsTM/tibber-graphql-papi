using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    public class Price
    {
        [Key]
        public int id { get; set; }
        public double total { get; set; }
        public double energy { get; set; }
        public double tax { get; set; }
        public DateTime startsAt { get; set; }
        public Enum.Currency currency { get; set; }
        public Enum.Level level { get; set; }

    }
}
