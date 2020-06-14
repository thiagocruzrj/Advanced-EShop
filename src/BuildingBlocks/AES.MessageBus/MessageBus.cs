﻿using AES.Core.Messages.Integration;
using EasyNetQ;
using System;
using System.Threading.Tasks;

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
    }
}
