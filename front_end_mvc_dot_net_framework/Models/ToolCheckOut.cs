using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace front_end_mvc_dot_net_framework.Models
{
    public class ToolCheckOut
    {
        public int id { get; set; }
        public string mechanic { get; set; }
        public string partName { get; set; }
        public string partType { get; set; }
        public Nullable<System.DateTime> date { get; set; }
    }
}