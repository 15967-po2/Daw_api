using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIMares.Authentication
{
    public class Response
    {
        public string Status { get; set; }
        public string Massage { get; set; }
        public string Message { get; internal set; }
    }
}
