using MediatR;

namespace MinimalApi.Modules.Hello;

public sealed class HelloHandler : IRequestHandler<HelloRequest, HelloResponse>
{
    private readonly IHelloService _helloService;

    public HelloHandler(IHelloService helloService)
    {
        _helloService = helloService;
    }

    public Task<HelloResponse> Handle(HelloRequest request, CancellationToken cancellationToken)
    {
        return string.IsNullOrWhiteSpace(request.Name) ?
            Task.FromResult(new HelloResponse(_helloService.SayHello())) :
            Task.FromResult(new HelloResponse(_helloService.SayHello(request.Name)));
    }
}
