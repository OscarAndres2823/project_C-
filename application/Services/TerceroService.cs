using MiniprojectC_.application.Ports;
using MiniprojectC_.domain.Entities;

namespace MiniprojectC_.application.Services
{
    public class TerceroService
    {
        private readonly ITerceroRepository _terceroRepository;

        public TerceroService(ITerceroRepository terceroRepository)
        {
            _terceroRepository = terceroRepository;
        }

        public void Crear(Tercero tercero)
        {
            _terceroRepository.Crear(tercero);
        }

        public List<Tercero> ObtenerTodos()
        {
            return _terceroRepository.ObtenerTodos();
        }

        public Tercero? ObtenerPorId(int id)
        {
            return _terceroRepository.ObtenerPorId(id);
        }

        public void Actualizar(Tercero tercero)
        {
            _terceroRepository.Actualizar(tercero);
        }

        public void Eliminar(int id)
        {
            _terceroRepository.Eliminar(id);
        }
    }
}
