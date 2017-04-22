using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerPortal.Models
{
    public class CustomerPaymentViewModel
    {
        public List<Customer> Customer { get; set; }
        public CustomerPayment Payment { get; set; }
    }
}