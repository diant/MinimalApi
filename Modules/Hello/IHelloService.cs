namespace MinimalApi.Modules.Hello;


public interface IHelloService
{
    string SayHello();
    string SayHello(string name);
}
