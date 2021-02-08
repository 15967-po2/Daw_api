using System;
using System.Collections.Generic;

#nullable disable

namespace MaresAPI.Models
{
    public class County
    {
        public int Id { get; set; }
        public string CountyName { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<Beach> Beaches { get; set; }
    }
}
