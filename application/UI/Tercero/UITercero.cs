using MiniprojectC_.application.Services;
using MiniprojectC_.domain.Entities;

namespace MiniprojectC_.application.UI.Terceros
{
    public class UITercero
    {
        private readonly TerceroService _terceroService;

        public UITercero(TerceroService terceroService)
        {
            _terceroService = terceroService;
        }

        public void Menu()
        {
            int opcion;
            do
            {
                Console.WriteLine("\n--- Menú Tercero ---");
                Console.WriteLine("1. Crear Tercero");
                Console.WriteLine("2. Mostrar Todos");
                Console.WriteLine("3. Buscar por ID");
                Console.WriteLine("4. Actualizar");
                Console.WriteLine("5. Eliminar");
                Console.WriteLine("0. Volver");
                Console.Write("Opción: ");
                int.TryParse(Console.ReadLine(), out opcion);

                switch (opcion)
                {
                    case 1: Crear(); break;
                    case 2: MostrarTodos(); break;
                    case 3: BuscarPorId(); break;
                    case 4: Actualizar(); break;
                    case 5: Eliminar(); break;
                }

            } while (opcion != 0);
        }

        private void Crear()
        {
            var t = new Tercero();
            Console.Write("Nombre: ");
            t.Nombre = Console.ReadLine()!;
            Console.Write("Tipo: ");
           t.TipoTerceroId = int.Parse(Console.ReadLine()!);
            _terceroService.Crear(t);
        }

        private void MostrarTodos()
        {
            var lista = _terceroService.ObtenerTodos();
            foreach (var t in lista)
            {
                Console.WriteLine($"ID: {t.Id}, Nombre: {t.Nombre}, Tipo: {t.TipoTerceroId}");
            }
        }

        private void BuscarPorId()
        {
            Console.Write("ID del tercero: ");
            int id = int.Parse(Console.ReadLine()!);
            var t = _terceroService.ObtenerPorId(id);
            if (t != null)
                Console.WriteLine($"ID: {t.Id}, Nombre: {t.Nombre}, Tipo: {t.TipoTerceroId}");
            else
                Console.WriteLine("No encontrado.");
        }

        private void Actualizar()
        {
            Console.Write("ID a actualizar: ");
            int id = int.Parse(Console.ReadLine()!);
            var t = _terceroService.ObtenerPorId(id);
            if (t == null)
            {
                Console.WriteLine("No encontrado.");
                return;
            }

            Console.Write("Nuevo nombre: ");
            t.Nombre = Console.ReadLine()!;
            Console.Write("Nuevo tipo: ");
            t.TipoTerceroId = int.Parse(Console.ReadLine()!);
            _terceroService.Actualizar(t);
        }

        private void Eliminar()
        {
            Console.Write("ID a eliminar: ");
            int id = int.Parse(Console.ReadLine()!);
            _terceroService.Eliminar(id);
        }
    }
}
