using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Shopping.WebUI.Models.Attributes;

public sealed class PositiveNumbersAttribute : ValidationAttribute
{

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is int number)
        {
            if (number < 0)
            {
                return new ValidationResult($"Error");
            }
        }

        return ValidationResult.Success;
    }
}