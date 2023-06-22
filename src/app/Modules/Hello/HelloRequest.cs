using MediatR;

namespace MinimalApi.Modules.Hello;

public record HelloRequest(string Name) : IRequest<HelloResponse>;