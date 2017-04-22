using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerPortal.Models
{
    public class BuyingReportVM
    {
        public IEnumerable<CustomerBuyingRecord> customerBuying { get; set; }

        public SearchPayment searchPayment { get; set; }

        public IEnumerable<Customer> Customers { get; set; }
    }
}