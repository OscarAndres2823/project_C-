using System;
using MiniprojectC_.Application.Services;
using MiniprojectC_.domain.Entities;

namespace MiniprojectC_.Application.UI.Eps
{
    public class UIEps
    {
        private readonly EpsService epsService = new();

        public void Menu()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=== CRUD EPS ===");
                Console.WriteLine("1. Crear EPS");
                Console.WriteLine("2. Ver EPS");
                Console.WriteLine("3. Actualizar EPS");
                Console.WriteLine("4. Eliminar EPS");
                Console.WriteLine("0. Volver al menú principal");
                Console.Write("Seleccione una opción: ");
                int.TryParse(Console.ReadLine(), out opcion);

                switch (opcion)
                {
                    case 1:
                        CrearEps();
                        break;
                    case 2:
                        VerEps();
                        break;
                    case 3:
                        ActualizarEps();
                        break;
                    case 4:
                        EliminarEps();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }

                if (opcion != 0)
                {
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 0);
        }

        private void CrearEps()
        {
            Console.Write("Ingrese nombre de la EPS: ");
            string nombre = Console.ReadLine();
            epsService.Crear(nombre);
            Console.WriteLine("EPS creada exitosamente.");
        }

        private void VerEps()
        {
            Console.WriteLine("--- Lista de EPS ---");
            var lista = epsService.ObtenerTodas();
            if (lista.Count == 0)
            {
                Console.WriteLine("No hay EPS registradas.");
            }
            else
            {
                foreach (var eps in lista)
                {
                    Console.WriteLine($"ID: {eps.Id}, Nombre: {eps.Nombre}");
                }
            }
        }

        private void ActualizarEps()
        {
            Console.Write("Ingrese el ID de la EPS a actualizar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Write("Nuevo nombre: ");
                string nuevoNombre = Console.ReadLine();
                if (epsService.Actualizar(id, nuevoNombre))
                    Console.WriteLine("EPS actualizada.");
                else
                    Console.WriteLine("EPS no encontrada.");
            }
        }

        private void EliminarEps()
        {
            Console.Write("Ingrese el ID de la EPS a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (epsService.Eliminar(id))
                    Console.WriteLine("EPS eliminada.");
                else
                    Console.WriteLine("EPS no encontrada.");
            }
        }
    }
}
