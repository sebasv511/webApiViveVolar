using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webApiViveVolar.Models
{
    public class Response
    {
        public int error_number { get; set; }
        public string error_message { get; set; }
        public object detail { get; set; }
    }
}