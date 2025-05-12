using System;
using MiniprojectC_.application.Services;
using MiniprojectC_.Domain;

namespace MiniprojectC_.application.UI.Configuraciones
{
    public class UICiudad
    {
        private readonly CiudadService _service;

        public UICiudad(CiudadService service)
        {
            _service = service;
        }

        public void MostrarMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("------ GESTIÓN DE CIUDADES ------");
                Console.WriteLine("1. Crear ciudad");
                Console.WriteLine("2. Ver ciudades");
                Console.WriteLine("3. Actualizar ciudad");
                Console.WriteLine("4. Eliminar ciudad");
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
            Console.Write("ID de la región: ");
            int regionId = int.Parse(Console.ReadLine());

            _service.Crear(new Ciudad { Id = id, Nombre = nombre, RegionId = regionId });
        }

        private void Ver()
        {
            var ciudades = _service.ObtenerTodos();
            foreach (var c in ciudades)
            {
                Console.WriteLine($"ID: {c.Id}, Nombre: {c.Nombre}, Región ID: {c.RegionId}");
            }
        }

        private void Actualizar()
        {
            Console.Write("ID de la ciudad a actualizar: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nuevo nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Nuevo ID de la región: ");
            int regionId = int.Parse(Console.ReadLine());

            _service.Actualizar(new Ciudad { Id = id, Nombre = nombre, RegionId = regionId });
        }

        private void Eliminar()
        {
            Console.Write("ID de la ciudad a eliminar: ");
            int id = int.Parse(Console.ReadLine());
            _service.Eliminar(id);
        }
    }
}
