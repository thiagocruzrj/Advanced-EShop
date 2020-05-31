using AES.Core.Messages;
using MediatR;
using System;

namespace AES.Core.Mediator
{
    public class Event : Message, INotification 
    {
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}