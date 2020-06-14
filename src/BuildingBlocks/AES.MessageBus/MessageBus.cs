using EasyNetQ;
using System;

namespace AES.MessageBus
{
    public class MessageBus : IMessageBus
    {
        private IBus _bus;

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    public interface IMessageBus : IDisposable
    {

    }
}
