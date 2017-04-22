using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerPortal.Models
{
    public class SearchPayment
    {
        public   DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string PayingCustomerId { get; set; }
    }
}