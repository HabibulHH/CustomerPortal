using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerPortal.Models
{
    public class DailySales
    {
        public int Id { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
        [Display(Name = "Total Amount")]
       
        public double Total { get; set; }
        [Required(ErrorMessage = "Give a date")]
        public DateTime SalesDate { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
        [Display(Name = "On Cash ")]
        public double OnCashSale { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
        [Display(Name = "On Due ")]
        public double OnDueSale { get; set; }
        
        [Required(ErrorMessage = "give a number ")]
        [Display(Name = "Collection ")]
        
        public double Collection { get; set; }

    }
}