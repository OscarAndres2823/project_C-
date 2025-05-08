using MiniprojectC_.domain.Entities;

namespace MiniprojectC_.domain.Ports;

public interface IEmpleadoRepository
{
    void Agregar(Empleado empleado);
    void Actualizar(Empleado empleado);
    void Eliminar(int id);
    Empleado? ObtenerPorId(int id);
    List<Empleado> ObtenerTodos();
}
