using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerPortal.Models
{
    public class ShowCompanyReportVM
    {
        public IEnumerable<CompanyPayment> companysPayments { get; set; }

        public SearchCompanyPayment searchPayment { get; set; }

        public IEnumerable<Compnay> Compnays { get; set; }
    }
}