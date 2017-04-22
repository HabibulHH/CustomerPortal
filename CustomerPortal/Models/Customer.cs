using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace CustomerPortal.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string  CustomerID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Region { get; set; }
        [Required]
        public double Balance { get; set; }
        [Required]
        public string MobileNumber { get; set; }
        [Required]
        public string CustomerType { get; set; }
        [Required]
        public DateTime OpenDate { get; set; }
    }
}