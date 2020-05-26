using System;

namespace AES.Core.Messages
{
    public abstract class Message
    {
        public string MessageType { get; private set; }
        public Guid AggregateId { get; private set; }

        public Message()
        {
            MessageType = GetType().Name;
        }
    }
}
