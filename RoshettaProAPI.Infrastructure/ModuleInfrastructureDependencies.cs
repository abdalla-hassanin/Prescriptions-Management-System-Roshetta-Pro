using Microsoft.Extensions.DependencyInjection;
using RoshettaProAPI.Infrustructure.Base;

namespace RoshettaProAPI.Infrustructure;

public static class ModuleInfrastructureDependencies
{
    public static void AddInfrastructureDependencies(this IServiceCollection services)
    {
        // Register UnitOfWork and GenericRepository
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    }
}