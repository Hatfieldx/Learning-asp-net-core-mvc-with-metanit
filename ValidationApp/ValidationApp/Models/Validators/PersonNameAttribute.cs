using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ValidationApp.Models.Validators
{
    public class PersonNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = "Hello";
            
            return base.IsValid(value, validationContext);
        }
    }
}
