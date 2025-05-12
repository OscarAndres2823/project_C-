using System;
using MiniprojectC_.application.Services;
using MiniprojectC_.Domain;

namespace MiniprojectC_.application.UI.Configuraciones
{
    public class UIRegion
    {
        private readonly RegionService _service;

        public UIRegion(RegionService service)
        {
            _service = service;
        }

        public void MostrarMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("------ GESTIÓN DE REGIONES ------");
                Console.WriteLine("1. Crear región");
                Console.WriteLine("2. Ver regiones");
                Console.WriteLine("3. Actualizar región");
                Console.WriteLine("4. Eliminar región");
                Console.WriteLine("0. Volver");
                Console.Write("Seleccione una opción: ");
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Crear();
                        break;
                    case "2":
                        Ver();
                        break;
                    case "3":
                        Actualizar();
                        break;
                    case "4":
                        Eliminar();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
            }
        }

        private void Crear()
        {
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("ID del país: ");
            int paisId = int.Parse(Console.ReadLine());

            _service.Crear(new Region { Id = id, Nombre = nombre, PaisId = paisId });
        }

        private void Ver()
        {
            var regiones = _service.ObtenerTodos();
            foreach (var r in regiones)
            {
                Console.WriteLine($"ID: {r.Id}, Nombre: {r.Nombre}, País ID: {r.PaisId}");
            }
        }

        private void Actualizar()
        {
            Console.Write("ID de la región a actualizar: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nuevo nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Nuevo ID del país: ");
            int paisId = int.Parse(Console.ReadLine());

            _service.Actualizar(new Region { Id = id, Nombre = nombre, PaisId = paisId });
        }

        private void Eliminar()
        {
            Console.Write("ID de la región a eliminar: ");
            int id = int.Parse(Console.ReadLine());
            _service.Eliminar(id);
        }
    }
}
