using MiniprojectC_.domain.Entities;

namespace MiniprojectC_.domain.Ports;

public interface IClienteRepository
{
    List<Cliente> GetAll();
    void Add(Cliente cliente);
    void Update(Cliente cliente);
    void Delete(int id);
}
