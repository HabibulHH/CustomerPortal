using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CustomerPortal.Models.Validation
{
    public class TotalCashValidator:ValidationAttribute 
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var sales = (DailySales)validationContext.ObjectInstance;
            bool isValid = Math.Abs(sales.Total - (sales.OnCashSale + sales.OnCashSale)) < .99;

            if (sales != null) return ValidationResult.Success;
            else new ValidationResult("Required filed");
            if (isValid) return ValidationResult.Success;
            else return new ValidationResult("Please Check: Total amount= On cash+on Due ");
            

        }
    }
}