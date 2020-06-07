using System;

namespace AES.Core.Messages.Integration
{
    public abstract class IntegrationEvent : Event 
    {
        
    }

    public class UserRegisteredIntegrationEvent : IntegrationEvent
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
    }
}
