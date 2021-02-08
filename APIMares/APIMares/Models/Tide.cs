using System;
using System.Collections.Generic;

#nullable disable

namespace MaresAPI.Models
{
    public class Tide
    {
        public int Id { get; set; }
        public DateTime Day { get; set; }
        public string TideType { get; set; }
        public string Time { get; set; }
        public float Height { get; set; }
        public int BeachId { get; set; }

        public virtual Beach Beach { get; set; }
        public int CountyId { get; internal set; }
    }
}
