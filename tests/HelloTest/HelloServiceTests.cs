using FluentAssertions;
using MinimalApi.Modules.Hello;

namespace HelloTest;

public class HelloServiceTests
{

    [Fact]
    public void HelloReturnsHello()
    {
        var helloService = new HelloService();
        var result = helloService.SayHello();
        result.Should().Be("Hello World!");
    }

    [Fact]
    public void HelloReturnsHelloName()
    {
        var helloService = new HelloService();
        var result = helloService.SayHello("John");
        result.Should().Be("Hello John!");
    }
}
