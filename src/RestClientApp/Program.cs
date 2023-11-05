using Newtonsoft.Json;
using System.Net.Http.Headers;

Console.WriteLine("Hello, World!");
string port;
if (args is null || args.Length == 0)
{
    Console.Write("Port? ");
    port = Console.ReadLine()!;
}
else
{
    port = args![0];
}
var url = $"http://localhost:{port}";
var httpClient = new HttpClient
{
    BaseAddress = new Uri(url)
};
httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

while (true)
{
    Console.Write("Action? ");
    var action = Console.ReadLine();

    Console.WriteLine($"Calling {url}/{action} ...");
    var response = await httpClient.GetAsync($"/{action}");
    var content = await response.Content.ReadAsStringAsync();
    var obj = JsonConvert.DeserializeObject<Result>(content);
    Console.WriteLine(content);
}

record Result(string Message);