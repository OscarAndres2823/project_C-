using System;
using System.Collections.Generic;
using MiniprojectC_.Domain;

namespace MiniprojectC_.application.Services
{
    public class RegionService
    {
        // Simulando la base de datos con una lista en memoria
        private readonly List<Region> _regiones;

        public RegionService()
        {
            // Inicializamos con algunos datos de ejemplo
            _regiones = new List<Region>
            {
                new Region { Id = 1, Nombre = "Región Norte", PaisId = 1 },
                new Region { Id = 2, Nombre = "Región Sur", PaisId = 1 }
            };
        }

        public void Crear(Region region)
        {
            _regiones.Add(region);
            Console.WriteLine("Región creada exitosamente.");
        }

        public List<Region> ObtenerTodos()
        {
            return _regiones;
        }

        public void Actualizar(Region region)
        {
            var regionExistente = _regiones.Find(r => r.Id == region.Id);
            if (regionExistente != null)
            {
                regionExistente.Nombre = region.Nombre;
                regionExistente.PaisId = region.PaisId;
                Console.WriteLine("Región actualizada exitosamente.");
            }
            else
            {
                Console.WriteLine("Región no encontrada.");
            }
        }

        public void Eliminar(int id)
        {
            var region = _regiones.Find(r => r.Id == id);
            if (region != null)
            {
                _regiones.Remove(region);
                Console.WriteLine("Región eliminada exitosamente.");
            }
            else
            {
                Console.WriteLine("Región no encontrada.");
            }
        }
    }
}
