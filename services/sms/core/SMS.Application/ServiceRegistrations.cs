using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace SMS.Application;

public static class ServiceRegistrations
{
    public static void AddApplicationServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(ServiceRegistrations).Assembly);
        });

        serviceCollection.AddHttpClient();
    }
}