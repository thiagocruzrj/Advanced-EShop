using AES.Core.Messages.Integration;
using EasyNetQ;
using System;
using System.Threading.Tasks;

namespace AES.MessageBus
{
    public class MessageBus : IMessageBus
    {
        private IBus _bus;

        private readonly string _connectionString;

        public MessageBus(string connectionString)
        {
            _connectionString = connectionString;
            TryConnect();
        }

        public bool IsConnected => _bus?.IsConnected ?? false;

        public void Publish<T>(T message) where T : IntegrationEvent
        {
            TryConnect();
            _bus.Publish(message);
        }

        public async Task PublishAsync<T>(T message) where T : IntegrationEvent
        {
            TryConnect();
            await _bus.PublishAsync(message);
        }

        public TResponse Request<TRequest, TResponse>(TRequest request)
            where TRequest : IntegrationEvent
            where TResponse : ResponseMessage
        {
            TryConnect();
            return _bus.Request<TRequest, TResponse>(request);
        }

        public Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request)
            where TRequest : IntegrationEvent
            where TResponse : ResponseMessage
        {
            throw new NotImplementedException();
        }

        public IDisposable Respond<TRequest, TResponse>(Func<TRequest, Task<TResponse>> respond)
            where TRequest : IntegrationEvent
            where TResponse : ResponseMessage
        {
            throw new NotImplementedException();
        }

        public Task<IDisposable> RespondAsync<TRequest, TResponse>(Func<TRequest, Task<TResponse>> respond)
            where TRequest : IntegrationEvent
            where TResponse : ResponseMessage
        {
            throw new NotImplementedException();
        }

        public void Subscribe<T>(string subscriptionId, Action<T> onMessage) where T : class
        {
            TryConnect();
            _bus.Subscribe(subscriptionId, onMessage);
        }

        public void SubscribeAsync<T>(string subscriptionId, Func<T, Task> onMessage) where T : class
        {
            TryConnect();
            _bus.SubscribeAsync(subscriptionId, onMessage);
        }

        private void TryConnect()
        {
            if (IsConnected) return;

            _bus = RabbitHutch.CreateBus(_connectionString);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    public interface IMessageBus : IDisposable
    {
        void Publish<T>(T message) where T : IntegrationEvent;
        Task PublishAsync<T>(T message) where T : IntegrationEvent;
        void Subscribe<T>(string subscriptionId, Action<T> onMessage) where T : class;
        void SubscribeAsync<T>(string subscriptionId, Func<T, Task> onMessage) where T : class;

        TResponse Request<TRequest, TResponse>(TRequest request)
            where TRequest : IntegrationEvent
            where TResponse : ResponseMessage;

        Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request)
            where TRequest : IntegrationEvent
            where TResponse : ResponseMessage;

        IDisposable Respond<TRequest, TResponse>(Func<TRequest, Task<TResponse>> respond)
            where TRequest : IntegrationEvent
            where TResponse : ResponseMessage;

        Task<IDisposable> RespondAsync<TRequest, TResponse>(Func<TRequest, Task<TResponse>> respond)
            where TRequest : IntegrationEvent
            where TResponse : ResponseMessage;

        bool IsConnected { get; }
    }
}
