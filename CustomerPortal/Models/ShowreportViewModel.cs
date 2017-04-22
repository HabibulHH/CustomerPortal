using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace CustomerPortal.Models
{
    public class ShowreportViewModel
    {
        public IEnumerable<CustomerPayment> customerPayments { get; set; }

        public SearchPayment searchPayment { get; set; }

        public IEnumerable<Customer> Customers { get; set; }
    }
}