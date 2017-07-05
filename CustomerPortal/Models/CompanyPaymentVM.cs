using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerPortal.Models
{
    public class CompanyPaymentVM
    {
        public List<Compnay> Company { get; set; }
        public CompanyPayment Payment { get; set; }
    }
}