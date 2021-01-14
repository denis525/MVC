using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSRtri.Models
{
    public class MojEmsoValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                int a = 0;
                int factor = 7;
                int sum = 0;
                char[] emso = value.ToString().ToArray();
                if (emso.Length < 12)
                {
                    return new ValidationResult("Emšo je prekratek!");
                }
                a = int.Parse((emso[4]).ToString());

                if (emso[3] == 2)
                {
                    return new ValidationResult("Emšo je nepravilen!");
                }
                else if ((emso[3] == 1) && (a < 2))
                {
                    return new ValidationResult("Emšo je nepravilen!");
                }
                for (int i = 0; i <= 11; i++)
                {
                    a = int.Parse((emso[i]).ToString());

                    if (factor == 1)
                    {
                        factor = 7;
                    }
                    sum = sum + a * factor;
                    factor--;
                }
                a = int.Parse((emso[12]).ToString());
                if ((sum % 11) == a)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Emso is incorrect!");
                }
            }
            else
            {
                return new ValidationResult("" + validationContext.DisplayName + " polje ne sme biti prazno!");
            }
        }
    }
}