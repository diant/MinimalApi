using MediatR;

namespace MinimalApi.Modules.Hello;

public class HelloModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/hello", async (IMediator mediator, CancellationToken cancellationToken) =>
            await mediator.Send(new HelloRequest(""), cancellationToken));

        endpoints.MapGet("/hello/{name}", async (string name, IMediator mediator, CancellationToken cancellationToken) =>
            await mediator.Send(new HelloRequest(name), cancellationToken));

        return endpoints;
    }

    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<IHelloService, HelloService>();

        return services;
    }
}