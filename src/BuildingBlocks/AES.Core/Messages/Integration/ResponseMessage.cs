using FluentValidation.Results;

namespace AES.Core.Messages.Integration
{
    public class ResponseMessage : Message
    {
        public ValidationResult ValidationResult { get; set; }
    }
}
