using Microsoft.AspNetCore.Http.HttpResults;

namespace MinimalApi.Modules.Hello;


public class HelloService : IHelloService
{
    public string SayHello() => "Hello World!";

    public string SayHello(string name) => $"Hello {name}!";
}
