using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    public class Viewer
    {
        [Key]
        public Guid userId { get; set; }
        public string name { get; set; }
        public Home home { get; set; }

    }
}
