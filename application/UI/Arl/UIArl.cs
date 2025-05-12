using System;
using MiniprojectC_.Application.Services;
using MiniprojectC_.Domain.Models;

namespace MiniprojectC_.Application.UI.Arl
{
    public class UIArl
    {
        private readonly ArlService arlService = new();

        public void Menu()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=== CRUD ARL ===");
                Console.WriteLine("1. Crear ARL");
                Console.WriteLine("2. Ver ARLs");
                Console.WriteLine("3. Actualizar ARL");
                Console.WriteLine("4. Eliminar ARL");
                Console.WriteLine("0. Volver al menú principal");
                Console.Write("Seleccione una opción: ");
                int.TryParse(Console.ReadLine(), out opcion);

                switch (opcion)
                {
                    case 1:
                        CrearArl();
                        break;
                    case 2:
                        VerArls();
                        break;
                    case 3:
                        ActualizarArl();
                        break;
                    case 4:
                        EliminarArl();
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

        private void CrearArl()
        {
            Console.Write("Ingrese nombre de la ARL: ");
            string nombre = Console.ReadLine();
            arlService.Crear(nombre);
            Console.WriteLine("ARL creada exitosamente.");
        }

        private void VerArls()
        {
            Console.WriteLine("--- Lista de ARLs ---");
            var lista = arlService.ObtenerTodas();
            if (lista.Count == 0)
            {
                Console.WriteLine("No hay ARLs registradas.");
            }
            else
            {
                foreach (var arl in lista)
                {
                    Console.WriteLine($"ID: {arl.Id}, Nombre: {arl.Nombre}");
                }
            }
        }

        private void ActualizarArl()
        {
            Console.Write("Ingrese el ID de la ARL a actualizar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Write("Nuevo nombre: ");
                string nuevoNombre = Console.ReadLine();
                if (arlService.Actualizar(id, nuevoNombre))
                    Console.WriteLine("ARL actualizada.");
                else
                    Console.WriteLine("ARL no encontrada.");
            }
        }

        private void EliminarArl()
        {
            Console.Write("Ingrese el ID de la ARL a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (arlService.Eliminar(id))
                    Console.WriteLine("ARL eliminada.");
                else
                    Console.WriteLine("ARL no encontrada.");
            }
        }
    }
}
