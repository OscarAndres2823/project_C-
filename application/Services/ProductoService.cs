using MiniprojectC_.domain.Entities;
using MiniprojectC_.domain.Ports;

namespace MiniprojectC_.application.Services;

public class ProductoService
{
    private readonly IProductoRepository _repository;

    public ProductoService(IProductoRepository repository)
    {
        _repository = repository;
    }

    public void Crear(Producto producto) => _repository.Agregar(producto);
    public void Actualizar(Producto producto) => _repository.Actualizar(producto);
    public void Eliminar(int id) => _repository.Eliminar(id);
    public Producto? ObtenerPorId(int id) => _repository.ObtenerPorId(id);
    public List<Producto> ObtenerTodos() => _repository.ObtenerTodos();
}
