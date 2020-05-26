using AES.Core.Messages;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AES.Core.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        public Task PublishEvent<T>(T evento) where T : Event
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> SendCommand<T>(T command) where T : Command
        {
            throw new NotImplementedException();
        }
    }
}
