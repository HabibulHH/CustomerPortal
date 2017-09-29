using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerPortal.Models
{
    public class SearchCompanyPayment
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int CompanyId { get; set; }
    }
}