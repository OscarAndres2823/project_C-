using System.Collections.Generic;
using MiniprojectC_.Domain;
using MiniprojectC_.infrastructure.mysql.repositories;

namespace MiniprojectC_.application.Services
{
    public class PaisService
    {
        private readonly PaisRepository _repository;

        public PaisService(PaisRepository repository)
        {
            _repository = repository;
        }

        public void Crear(Pais pais) => _repository.Crear(pais);
        public List<Pais> ObtenerTodos() => _repository.ObtenerTodos();
        public void Actualizar(Pais pais) => _repository.Actualizar(pais);
        public void Eliminar(int id) => _repository.Eliminar(id);
    }
}
