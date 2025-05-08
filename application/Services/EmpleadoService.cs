using MiniprojectC_.domain.Entities;
using MiniprojectC_.domain.Ports;

namespace MiniprojectC_.application.Services;

public class EmpleadoService
{
    private readonly IEmpleadoRepository _repository;

    public EmpleadoService(IEmpleadoRepository repository)
    {
        _repository = repository;
    }

    public void Crear(Empleado empleado) => _repository.Agregar(empleado);
    public void Actualizar(Empleado empleado) => _repository.Actualizar(empleado);
    public void Eliminar(int id) => _repository.Eliminar(id);
    public Empleado? ObtenerPorId(int id) => _repository.ObtenerPorId(id);
    public List<Empleado> ObtenerTodos() => _repository.ObtenerTodos();
}
