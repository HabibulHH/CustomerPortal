using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerPortal.Models
{
    public class Settings
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string RepportType { get; set; }
    }
}