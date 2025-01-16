using MinimalAPIExample.Models;

namespace MinimalAPIExample.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly Dictionary<Guid, Cliente> _cliente = new();

        public void Create(Cliente cliente)
        {
            if (cliente is null)
                return;

            _cliente[cliente.Id] = cliente;
        }

        public Cliente GetBydId(Guid id)
        {
            return _cliente[id];
        }

        public List<Cliente> GetAll()
        {
            return _cliente.Values.ToList();
        }

        public void Update(Cliente cliente)
        {
            var existingCliente = GetBydId(cliente.Id);
            if (existingCliente is null)
                return;

            _cliente[cliente.Id] = cliente;
        }

        public void Delete(Guid id)
        {
            _cliente.Remove(id);
        }
    }
}
