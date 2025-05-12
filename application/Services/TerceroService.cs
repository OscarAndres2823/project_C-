using MiniprojectC_.domain.Entities;
using MiniprojectC_.infrastructure.mysql.Repositories;

namespace MiniprojectC_.application.Services
{
    public class TerceroService
    {
        private readonly TerceroRepository _repo;

        public TerceroService(TerceroRepository repo)
        {
            _repo = repo;
        }

        public void Crear(Tercero t) => _repo.Crear(t);
        public List<Tercero> ObtenerTodos() => _repo.ObtenerTodos();
        public Tercero? ObtenerPorId(int id) => _repo.ObtenerPorId(id);
        public void Actualizar(Tercero t) => _repo.Actualizar(t);
        public void Eliminar(int id) => _repo.Eliminar(id);
    }
}
