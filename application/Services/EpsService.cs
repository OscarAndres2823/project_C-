using System.Collections.Generic;
using System.Linq;
using MiniprojectC_.domain.Entities;

namespace MiniprojectC_.Application.Services
{
    public class EpsService
    {
        private List<Eps> epsList = new();
        private int _nextId = 1;

        public void Crear(string nombre)
        {
            epsList.Add(new Eps { Id = _nextId++, Nombre = nombre });
        }

        public List<Eps> ObtenerTodas()
        {
            return epsList;
        }

        public Eps ObtenerPorId(int id)
        {
            return epsList.FirstOrDefault(e => e.Id == id);
        }

        public bool Actualizar(int id, string nuevoNombre)
        {
            var eps = ObtenerPorId(id);
            if (eps != null)
            {
                eps.Nombre = nuevoNombre;
                return true;
            }
            return false;
        }

        public bool Eliminar(int id)
        {
            var eps = ObtenerPorId(id);
            if (eps != null)
            {
                epsList.Remove(eps);
                return true;
            }
            return false;
        }
    }
}
