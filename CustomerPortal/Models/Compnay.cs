using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerPortal.Models
{
    public class Compnay
    {
        public int Id { get; set; }
        
        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Give a Name")]
        public string CompanyName { get; set; }
        [Display(Name = "Company Baki Amount")]
        [Required(ErrorMessage = "Give a Amount")]
        public double BakiAmount { get; set; }
        [Display(Name = "Company Mobile Number")]
        [Required(ErrorMessage = "Give a Mobile Number")]
        public string MobileNumber { get; set; }


    }
}