using AES.Core.DomainObjects;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;
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

    public class CpfAttributeAdapter : AttributeAdapterBase<CpfAttribute>
    {
        public CpfAttributeAdapter(CpfAttribute attribute, IStringLocalizer stringLocalizer) : base(attribute, stringLocalizer) { }

        public override void AddValidation(ClientModelValidationContext context)
        {
            throw new System.NotImplementedException();
        }

        public override string GetErrorMessage(ModelValidationContextBase validationContext)
        {
            throw new System.NotImplementedException();
        }
    }
}
