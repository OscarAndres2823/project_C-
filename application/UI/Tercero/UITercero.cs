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
                Console.Clear();
                Console.WriteLine("---- CRUD TERCERO ----");
                Console.WriteLine("1. Listar");
                Console.WriteLine("2. Agregar");
                Console.WriteLine("3. Editar");
                Console.WriteLine("4. Eliminar");
                Console.WriteLine("0. Salir");
                Console.Write("Opción: ");
                int.TryParse(Console.ReadLine(), out opcion);

                switch (opcion)
                {
                    case 1: Listar(); break;
                    case 2: Agregar(); break;
                    case 3: Editar(); break;
                    case 4: Eliminar(); break;
                }

            } while (opcion != 0);
        }

        private void Listar()
        {
            Console.Clear();
            Console.WriteLine("---- LISTA DE TERCEROS ----");
            var terceros = _terceroService.ObtenerTodos();
            
            if (terceros.Count == 0)
            {
                Console.WriteLine("No hay terceros registrados.");
            }
            else
            {
                foreach (var t in terceros)
                {
                    Console.WriteLine($"ID: {t.Id} | Nombre: {t.Nombre} {t.Apellidos} | Email: {t.Email}");
                }
            }
            
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private void Agregar()
        {
            Console.Clear();
            Console.WriteLine("---- AGREGAR TERCERO ----");
            
            var tercero = new Tercero();
            
            Console.Write("Nombre: ");
            tercero.Nombre = Console.ReadLine() ?? string.Empty;
            
            Console.Write("Apellidos: ");
            tercero.Apellidos = Console.ReadLine() ?? string.Empty;
            
            Console.Write("Email: ");
            tercero.Email = Console.ReadLine() ?? string.Empty;
            
            Console.Write("Tipo de Documento ID: ");
            if (int.TryParse(Console.ReadLine(), out int tipoDocId))
            {
                tercero.TipoDocumentoId = tipoDocId;
            }
            else
            {
                Console.WriteLine("ID de tipo de documento inválido. Se asignará 1 por defecto.");
                tercero.TipoDocumentoId = 1;
            }
            
            Console.Write("Tipo de Tercero ID: ");
            if (int.TryParse(Console.ReadLine(), out int tipoTerceroId))
            {
                tercero.TipoTerceroId = tipoTerceroId;
            }
            else
            {
                Console.WriteLine("ID de tipo de tercero inválido. Se asignará 1 por defecto.");
                tercero.TipoTerceroId = 1;
            }
            
            Console.Write("Ciudad ID: ");
            if (int.TryParse(Console.ReadLine(), out int ciudadId))
            {
                tercero.CiudadId = ciudadId;
            }
            else
            {
                Console.WriteLine("ID de ciudad inválido. Se asignará 1 por defecto.");
                tercero.CiudadId = 1;
            }
            
            try
            {
                _terceroService.Crear(tercero);
                Console.WriteLine("Tercero agregado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar tercero: {ex.Message}");
            }
            
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private void Editar()
        {
            Console.Clear();
            Console.WriteLine("---- EDITAR TERCERO ----");
            
            Console.Write("Ingrese el ID del tercero a editar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido.");
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }
            
            var tercero = _terceroService.ObtenerPorId(id);
            if (tercero == null)
            {
                Console.WriteLine("Tercero no encontrado.");
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }
            
            Console.WriteLine($"Editando tercero: {tercero.Nombre} {tercero.Apellidos}");
            
            Console.Write("Nuevo nombre (deje en blanco para mantener el actual): ");
            string nombre = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(nombre))
            {
                tercero.Nombre = nombre;
            }
            
            Console.Write("Nuevos apellidos (deje en blanco para mantener los actuales): ");
            string apellidos = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(apellidos))
            {
                tercero.Apellidos = apellidos;
            }
            
            Console.Write("Nuevo email (deje en blanco para mantener el actual): ");
            string email = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(email))
            {
                tercero.Email = email;
            }
            
            Console.Write("Nuevo tipo de documento ID (deje en blanco para mantener el actual): ");
            string tipoDocInput = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(tipoDocInput) && int.TryParse(tipoDocInput, out int tipoDocId))
            {
                tercero.TipoDocumentoId = tipoDocId;
            }
            
            Console.Write("Nuevo tipo de tercero ID (deje en blanco para mantener el actual): ");
            string tipoTerceroInput = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(tipoTerceroInput) && int.TryParse(tipoTerceroInput, out int tipoTerceroId))
            {
                tercero.TipoTerceroId = tipoTerceroId;
            }
            
            Console.Write("Nueva ciudad ID (deje en blanco para mantener la actual): ");
            string ciudadInput = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(ciudadInput) && int.TryParse(ciudadInput, out int ciudadId))
            {
                tercero.CiudadId = ciudadId;
            }
            
            try
            {
                _terceroService.Actualizar(tercero);
                Console.WriteLine("Tercero actualizado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar tercero: {ex.Message}");
            }
            
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private void Eliminar()
        {
            Console.Clear();
            Console.WriteLine("---- ELIMINAR TERCERO ----");
            
            Console.Write("Ingrese el ID del tercero a eliminar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido.");
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }
            
            var tercero = _terceroService.ObtenerPorId(id);
            if (tercero == null)
            {
                Console.WriteLine("Tercero no encontrado.");
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }
            
            Console.WriteLine($"¿Está seguro de eliminar el tercero: {tercero.Nombre} {tercero.Apellidos}? (S/N)");
            string respuesta = Console.ReadLine() ?? string.Empty;
            
            if (respuesta.ToUpper() == "S")
            {
                try
                {
                    _terceroService.Eliminar(id);
                    Console.WriteLine("Tercero eliminado correctamente.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al eliminar tercero: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Operación cancelada.");
            }
            
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
