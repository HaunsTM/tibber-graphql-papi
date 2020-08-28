using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    public class Home
    {
        [Key]
        public Guid id { get; set; }

        // Navigation property
        public virtual ICollection<Subscription> subscriptions { get; set; }

    }
}