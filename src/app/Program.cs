using FluentValidation;
using MinimalApi.Modules;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddLogging();
builder.Services.RegisterModules();
builder.Services.AddValidatorsFromAssemblyContaining(typeof(Program));
var app = builder.Build();

app.MapEndpoints();

app.UseMiddleware<LoggingMiddleware>();

app.MapGet("/", () => Results.Redirect("/hello"));
app.Run();
