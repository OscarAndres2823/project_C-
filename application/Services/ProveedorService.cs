using MiniprojectC_.domain.Entities;
using MiniprojectC_.infrastructure.mysql.repositories;

namespace MiniprojectC_.application.services;

public class ProveedorService
{
    private readonly ProveedorRepository _repositorio;

    public ProveedorService(ProveedorRepository repositorio)
    {
        _repositorio = repositorio;
    }

    public void Crear(Proveedor proveedor) => _repositorio.Agregar(proveedor);
    public void Editar(Proveedor proveedor) => _repositorio.Actualizar(proveedor);
    public void Eliminar(int id) => _repositorio.Eliminar(id);
    public List<Proveedor> Listar() => _repositorio.ObtenerTodos();
}
