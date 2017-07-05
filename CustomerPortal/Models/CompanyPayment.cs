using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerPortal.Models
{
    public class CompanyPayment
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime PaymentDate { get; set; }
        [Required(ErrorMessage = "Give amount")]
        public double Amount { get; set; }
        [Required(ErrorMessage = "Give Company Name")]
        public int CompanyId { get; set; }
    }
}