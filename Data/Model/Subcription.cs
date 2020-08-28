using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    public class Subscription
    {
        [Key]
        public Guid id { get; set; }
        public PriceInfo priceInfo { get; set; }

    }
}
