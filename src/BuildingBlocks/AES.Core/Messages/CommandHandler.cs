using FluentValidation.Results;

namespace AES.Core.Messages
{
    public abstract class CommandHandler
    {
        protected ValidationResult ValidationResult;

        protected CommandHandler(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }
    }
}
