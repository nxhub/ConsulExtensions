using System;
using Consul;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConsulServiceCollectionExtensions
    {
        public static IServiceCollection AddConsulClient(this IServiceCollection services)
        {
            return services.AddTransient<IConsulClient, ConsulClient>();
        }

        public static IServiceCollection AddConsulClient(
            this IServiceCollection services, Action<ConsulClientConfiguration> configOptions)
        {
            return services.AddTransient<IConsulClient>(provider =>
            {
                return new ConsulClient(configOptions);
            });
        }

        public static IServiceCollection AddConsulClient(
            this IServiceCollection services, Action<IServiceProvider, ConsulClientConfiguration> configOptions)
        {
            return services.AddTransient<IConsulClient>(provider =>
            {
                return new ConsulClient(options => configOptions?.Invoke(provider, options));
            });
        }
    }
}
