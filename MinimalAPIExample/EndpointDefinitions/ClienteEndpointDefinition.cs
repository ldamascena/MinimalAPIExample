using Microsoft.AspNetCore.Mvc;
using MinimalAPIExample.Models;
using MinimalAPIExample.Repositories;
using MinimalAPIExample.SecretSauce;
using System.Reflection.Metadata.Ecma335;

namespace MinimalAPIExample.EndpointDefinitions
{
    public class ClienteEndpointDefinition : IEndpointDefinition
    {
        public void DefineEndpoints(WebApplication app)
        {
            app.MapGet("/clientes", GetAllClientes);
            app.MapGet("/clientes/{id}", GetClienteById);
            app.MapPost("/clientes", CreateCliente);
            app.MapPut("/clientes/{id}", UpdateCliente);
            app.MapDelete("/clientes/{id}", DeleteCliente);
        }

        internal List<Cliente> GetAllClientes(IClienteRepository repo) => repo.GetAll();
        internal IResult GetClienteById(IClienteRepository repo, Guid id)
        {
            var cliente = repo.GetBydId(id);
            return cliente is not null ? Results.Ok(cliente) : Results.NotFound();
        }

        internal IResult CreateCliente(IClienteRepository repo, Cliente cliente)
        {
            repo.Create(cliente);
            return Results.Created($"/clientes/{cliente.Id}", cliente);
        }

        internal IResult UpdateCliente(IClienteRepository repo, Guid id, Cliente updatedCliente)
        {
            var cliente = repo.GetBydId(id);
            if (cliente is null)
                return Results.NotFound();

            repo.Update(updatedCliente);
            return Results.Ok(updatedCliente);
        }

        internal IResult DeleteCliente(IClienteRepository repo, Guid id)
        {
            repo.Delete(id);
            return Results.Ok();
        }

        public void DefineServices(IServiceCollection services)
        {
            services.AddSingleton<IClienteRepository, ClienteRepository>();
        }
    }
}
