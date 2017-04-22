using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerPortal.Models
{
    public class CustomerBuyingViewModel
    {
        public List<Customer> Customers { get; set; }
        public CustomerBuyingRecord BuyingRecord { get; set; }
    }
}