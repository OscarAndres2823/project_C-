using System;
using System.Collections.Generic;
using MiniprojectC_.Domain;

namespace MiniprojectC_.application.Services
{
    public class CiudadService
    {
        // Simulando la base de datos con una lista en memoria
        private readonly List<Ciudad> _ciudades;

        public CiudadService()
        {
            // Inicializamos con algunos datos de ejemplo
            _ciudades = new List<Ciudad>
            {
                new Ciudad { Id = 1, Nombre = "Ciudad A", RegionId = 1 },
                new Ciudad { Id = 2, Nombre = "Ciudad B", RegionId = 1 }
            };
        }

        public void Crear(Ciudad ciudad)
        {
            _ciudades.Add(ciudad);
            Console.WriteLine("Ciudad creada exitosamente.");
        }

        public List<Ciudad> ObtenerTodos()
        {
            return _ciudades;
        }

        public void Actualizar(Ciudad ciudad)
        {
            var ciudadExistente = _ciudades.Find(c => c.Id == ciudad.Id);
            if (ciudadExistente != null)
            {
                ciudadExistente.Nombre = ciudad.Nombre;
                ciudadExistente.RegionId = ciudad.RegionId;
                Console.WriteLine("Ciudad actualizada exitosamente.");
            }
            else
            {
                Console.WriteLine("Ciudad no encontrada.");
            }
        }

        public void Eliminar(int id)
        {
            var ciudad = _ciudades.Find(c => c.Id == id);
            if (ciudad != null)
            {
                _ciudades.Remove(ciudad);
                Console.WriteLine("Ciudad eliminada exitosamente.");
            }
            else
            {
                Console.WriteLine("Ciudad no encontrada.");
            }
        }
    }
}
