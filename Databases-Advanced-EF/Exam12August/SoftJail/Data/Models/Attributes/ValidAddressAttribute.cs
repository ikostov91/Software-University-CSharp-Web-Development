using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace SoftJail.Data.Models.Attributes
{
    public class ValidAddressAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string nullErrorMsg = "Address cannot be null!";

            if (value == null)
            {
                return new ValidationResult(nullErrorMsg);
            }

            string text = (string) value;

            string errorMsg = "Address is not valid!";

            bool isValid = Regex.IsMatch(text, @"^[A-Za-z0-9 ]+ str\.$");

            if (!isValid)
            {
                return new ValidationResult(errorMsg);
            }

            return ValidationResult.Success;
        }
    }
}
