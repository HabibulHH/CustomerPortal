using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerPortal.Models
{
    public class YearlySalesvm
    {
        public string   Year { get; set; }
        public double Total { get; set; }
        public double   OnDue { get; set; }

        public double OnCash { get; set; }
       
        public double Collection { get; set; }
    }
}