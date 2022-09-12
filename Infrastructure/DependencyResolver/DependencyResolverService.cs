using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyResolver;

public static class DependencyResolverService
{
    public static void RegisterInfrastructure(IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
    }
}