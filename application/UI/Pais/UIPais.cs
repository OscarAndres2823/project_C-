using System;
using MiniprojectC_.application.Services;
using MiniprojectC_.Domain;

namespace MiniprojectC_.application.UI.Configuraciones
{
    public class UIPais
    {
        private readonly PaisService _service;

        public UIPais(PaisService service)
        {
            _service = service;
        }

        public void MostrarMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("------ GESTIÓN DE PAISES ------");
                Console.WriteLine("1. Crear país");
                Console.WriteLine("2. Ver países");
                Console.WriteLine("3. Actualizar país");
                Console.WriteLine("4. Eliminar país");
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

            // Aquí debes crear un objeto de tipo Pais, no UIPais
            _service.Crear(new Pais { Id = id, Nombre = nombre });
        }

        private void Ver()
        {
            var paises = _service.ObtenerTodos();
            foreach (var p in paises)
            {
                Console.WriteLine($"ID: {p.Id}, Nombre: {p.Nombre}");
            }
        }

        private void Actualizar()
        {
            Console.Write("ID del país a actualizar: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nuevo nombre: ");
            string nombre = Console.ReadLine();

            _service.Actualizar(new Pais { Id = id, Nombre = nombre });
        }

        private void Eliminar()
        {
            Console.Write("ID del país a eliminar: ");
            int id = int.Parse(Console.ReadLine());
            _service.Eliminar(id);
        }
    }
}
