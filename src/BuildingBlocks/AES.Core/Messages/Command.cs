using System;

namespace AES.Core.Messages
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; private set; }
        protected Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
