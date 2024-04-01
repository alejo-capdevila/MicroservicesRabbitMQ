using MediatR;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.Bus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.Extensions.Options;

namespace MicroRabbit.Infra.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {

            //MediaTr Mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            //Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
                {
                    var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                    var optionsFactory = sp.GetService<IOptions<RabbitMQSettings>>();
                    return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory, optionsFactory);
                });

            return services;
        }
    }
}
