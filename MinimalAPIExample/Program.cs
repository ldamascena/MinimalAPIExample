using MinimalAPIExample.Models;
using MinimalAPIExample.SecretSauce;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointDefinitions(typeof(Cliente));

var app = builder.Build();
app.UseEndpointDefinitions();

app.Run();