using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerPortal.Models
{
    public class CustomerBuyingRecord
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Give positive amount")]
        
        public double Amount { get; set; }
        [Required(ErrorMessage = "Give a date of buying")]
        public DateTime  BuyingDate { get; set; }
        [Required(ErrorMessage = "Select  a customer Id")]
        public string BuyingCustomerId { get; set; }
    }
}