using System;
using System.Collections.Generic;

#nullable disable

namespace MaresAPI.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location1 { get; set; }

        public virtual ICollection<County> Counties { get; set; }
    }
}
