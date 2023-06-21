using MediatR;
using MinimalApi.Middlewares;
using System.Reflection;

namespace MinimalApi.Modules;

public static class ModuleExtensions
{
    // this could also be added into the DI container
    static readonly HashSet<IModule> registeredModules = new();

    public static IServiceCollection RegisterModules(this IServiceCollection services)
    {
        var modules = DiscoverModules();
        foreach (var module in modules)
        {
            module.RegisterModule(services);
            registeredModules.Add(module);
        }

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(typeof(IModule).Assembly);
        });
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

        return services;
    }

    public static WebApplication MapEndpoints(this WebApplication app)
    {
        foreach (var module in registeredModules)
        {
            module.MapEndpoints(app);
        }
        return app;
    }

    private static IEnumerable<IModule> DiscoverModules()
    {
        var assembly = Assembly.GetExecutingAssembly();

        return assembly//typeof(IModule).Assembly
            .GetTypes()
            .Where(p => p.IsClass && p.IsAssignableTo(typeof(IModule)))
            .Select(Activator.CreateInstance)
            .Cast<IModule>();
    }
}