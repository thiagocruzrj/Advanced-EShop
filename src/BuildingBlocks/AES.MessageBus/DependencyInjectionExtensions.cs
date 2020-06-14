using EasyNetQ.LightInject;
using Microsoft.Extensions.DependencyInjection;

namespace AES.MessageBus
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceContainer AddMessageBus(this IServiceCollection services, string connection)
        {
        }
    }
}
