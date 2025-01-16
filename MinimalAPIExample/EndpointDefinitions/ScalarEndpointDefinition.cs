using MinimalAPIExample.SecretSauce;
using Scalar.AspNetCore;

namespace MinimalAPIExample.EndpointDefinitions
{
    public class ScalarEndpointDefinition : IEndpointDefinition
    {
        public void DefineEndpoints(WebApplication app)
        {
            app.MapGet("/", () => Results.Redirect("/scalar/v1"));
            app.UseSwagger(options =>
            {
                options.RouteTemplate = "/openapi/{documentName}.json";
            });
            app.MapScalarApiReference(opt => opt
            .WithDarkMode(true)
            .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient));

        }

        public void DefineServices(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
