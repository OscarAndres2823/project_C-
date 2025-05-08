using MiniprojectC_.domain.Entities;

namespace MiniprojectC_.domain.Ports;

public interface IProductoRepository
{
    void Agregar(Producto producto);
    void Actualizar(Producto producto);
    void Eliminar(int id);
    Producto? ObtenerPorId(int id);
    List<Producto> ObtenerTodos();
}
