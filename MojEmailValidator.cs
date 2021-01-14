using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace DSRtri.Models
{
    public class MojEmailValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string email = value.ToString();

                if (Regex.IsMatch(email, @"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", RegexOptions.IgnoreCase))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Insert correct email!.");
                }
            }
            else
            {
                return new ValidationResult("" + validationContext.DisplayName + " field cannot be empty!");
            }
        }
    }
}