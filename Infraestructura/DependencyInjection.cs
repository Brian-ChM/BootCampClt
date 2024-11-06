using Core.Interfaces.Repositories;
using Infraestructura.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructura;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICustomerRepository, CustomerRepository>();

        return services;
    }
}
