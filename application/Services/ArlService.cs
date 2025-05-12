using System.Collections.Generic;
using System.Linq;
using MiniprojectC_.Domain.Models;

namespace MiniprojectC_.Application.Services
{
    public class ArlService
    {
        private List<Arl> arlList = new();
        private int _nextId = 1;

        public void Crear(string nombre)
        {
            arlList.Add(new Arl { Id = _nextId++, Nombre = nombre });
        }

        public List<Arl> ObtenerTodas()
        {
            return arlList;
        }

        public Arl ObtenerPorId(int id)
        {
            return arlList.FirstOrDefault(a => a.Id == id);
        }

        public bool Actualizar(int id, string nuevoNombre)
        {
            var arl = ObtenerPorId(id);
            if (arl != null)
            {
                arl.Nombre = nuevoNombre;
                return true;
            }
            return false;
        }

        public bool Eliminar(int id)
        {
            var arl = ObtenerPorId(id);
            if (arl != null)
            {
                arlList.Remove(arl);
                return true;
            }
            return false;
        }
    }
}
