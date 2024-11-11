using Core.Interfaces.Repositories;
using Infraestructura.Context;
using Infraestructura.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Core.DTOs;
using Infraestructura.Validation;

namespace Infraestructura;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();

        return services;
    }

    public static IServiceCollection AddDatabase
        (this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionStrings = configuration.GetConnectionString("connection");
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionStrings);
        });

        return services;
    }

    public static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services.AddScoped<IValidator<CreateCustomerDTO>, CreateValidation>();
        services.AddScoped<IValidator<UpdateCustomerDTO>, UpdateValidation>();
        return services;
    }
}
