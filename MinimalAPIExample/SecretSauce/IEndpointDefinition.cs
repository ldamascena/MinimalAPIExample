namespace MinimalAPIExample.SecretSauce
{
    public interface IEndpointDefinition
    {
        void DefineEndpoints(WebApplication web);
        void DefineServices(IServiceCollection services);
    }
}
