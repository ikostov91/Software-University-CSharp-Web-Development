using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace SoftJail.Data.Models.Attributes
{
    public class ValidNicknameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string nullErrorMsg = "Nickname cannot be null!";

            if (value == null)
            {
                return new ValidationResult(nullErrorMsg);
            }

            string text = (string) value;

            bool isValid = Regex.IsMatch(text, @"^The [A-Z][a-z]+$");

            string errorMsg = "Nickname is not valid";

            if (!isValid)
            {
                return new ValidationResult(errorMsg);
            }

            return ValidationResult.Success;
        }
    }
}
