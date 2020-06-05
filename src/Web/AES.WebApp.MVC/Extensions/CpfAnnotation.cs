using AES.Core.DomainObjects;
using System.ComponentModel.DataAnnotations;

namespace AES.WebApp.MVC.Extensions
{
    public class CpfAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return Cpf.Validate(value.ToString()) ? ValidationResult.Success : new ValidationResult("Invalid Cpf format");
        }
    }
}
