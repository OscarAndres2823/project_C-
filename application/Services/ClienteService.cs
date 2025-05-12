using MiniprojectC_.domain.Entities;
using MiniprojectC_.domain.Ports;

namespace MiniprojectC_.application.Services;

public class ClienteService
{
    private readonly IClienteRepository _repository;

    public ClienteService(IClienteRepository repository)
    {
        _repository = repository;
    }

    public List<Cliente> GetAll() => _repository.GetAll();
    public void Add(Cliente cliente) => _repository.Add(cliente);
    public void Update(Cliente cliente) => _repository.Update(cliente);
    public void Delete(int id) => _repository.Delete(id);
}
