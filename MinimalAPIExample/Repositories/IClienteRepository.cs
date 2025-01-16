using MinimalAPIExample.Models;

namespace MinimalAPIExample.Repositories
{
    public interface IClienteRepository
    {
        void Create(Cliente cliente);
        Cliente GetBydId(Guid id);
        List<Cliente> GetAll();
        void Update(Cliente cliente);
        void Delete(Guid id);

    }
}
