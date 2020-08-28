using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    public class PriceInfo
    {
        [Key]
        public int id { get; set; }

        // Navigation property
        public virtual ICollection<Price> today { get; set; }
    }
}
