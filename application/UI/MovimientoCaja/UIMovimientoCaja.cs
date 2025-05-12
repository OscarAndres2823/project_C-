using System;
using MiniprojectC_.application.Services;
using MiniprojectC_.Application.Services;
using MiniprojectC_.Domain;

namespace MiniprojectC_.Application.UI.Configuraciones
{
    public class UIMovimientoCaja
    {
        private readonly MovimientoCajaService _service;
        private readonly TerceroService _terceroService;  // Usar el servicio Tercero

        public UIMovimientoCaja(MovimientoCajaService service, TerceroService terceroService)
        {
            _service = service;
            _terceroService = terceroService;  // Inyectamos el servicio Tercero
        }

        public void MostrarMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("------ GESTIÓN DE MOVIMIENTOS DE CAJA ------");
                Console.WriteLine("1. Crear movimiento de caja");
                Console.WriteLine("2. Ver movimientos de caja");
                Console.WriteLine("3. Actualizar movimiento de caja");
                Console.WriteLine("4. Eliminar movimiento de caja");
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
            Console.Write("Fecha (yyyy-mm-dd): ");
            DateTime fecha = DateTime.Parse(Console.ReadLine());
            Console.Write("Tipo Movimiento ID: ");
            int tipoMovimientoId = int.Parse(Console.ReadLine());
            Console.Write("Valor: ");
            decimal valor = decimal.Parse(Console.ReadLine());
            Console.Write("Concepto: ");
            string concepto = Console.ReadLine();
            Console.Write("Tercero ID (debe ser un tercero válido): ");
            int terceroId = int.Parse(Console.ReadLine());

            // Usar el CRUD de Tercero para obtener el Tercero completo
            var tercero = _terceroService.ObtenerPorId(terceroId);

            if (tercero == null)
            {
                Console.WriteLine("No se encontró un tercero con ese ID.");
                return;
            }

            _service.Crear(new MovimientoCaja
            {
                Id = id,
                Fecha = fecha,
                TipoMovimientoCajaId = tipoMovimientoId,
                Monto = valor,
                Descripcion = concepto, 
                TerceroId = terceroId
            });

            Console.WriteLine("Movimiento de caja creado exitosamente.");
        }

        private void Ver()
        {
            var movimientos = _service.ObtenerTodos();
            foreach (var m in movimientos)
            {
                // Mostrar también el nombre del tercero
                        var tercero = _terceroService.ObtenerPorId(m.TerceroId);
                        Console.WriteLine($"ID: {m.Id}, Fecha: {m.Fecha}, Valor: {m.Monto}, Concepto: {m.Descripcion}, Tercero: {tercero?.Nombre ?? "Desconocido"}");
            }
        }

        private void Actualizar()
        {
            Console.Write("ID del movimiento a actualizar: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nueva fecha (yyyy-mm-dd): ");
            DateTime fecha = DateTime.Parse(Console.ReadLine());
            Console.Write("Nuevo Tipo Movimiento ID: ");
            int tipoMovimientoId = int.Parse(Console.ReadLine());
            Console.Write("Nuevo Valor: ");
            decimal valor = decimal.Parse(Console.ReadLine());
            Console.Write("Nuevo Concepto: ");
            string concepto = Console.ReadLine();
            Console.Write("Nuevo Tercero ID: ");
            int terceroId = int.Parse(Console.ReadLine());

            // Usar el CRUD de Tercero para obtener el Tercero completo
            var tercero = _terceroService.ObtenerPorId(terceroId);

            if (tercero == null)
            {
                Console.WriteLine("No se encontró un tercero con ese ID.");
                return;
            }

            _service.Actualizar(new MovimientoCaja
            {
                Id = id,
                Fecha = fecha,
                TipoMovimientoCajaId = tipoMovimientoId,
                Monto = valor,
                Descripcion = concepto,
                TerceroId = terceroId
            });

            Console.WriteLine("Movimiento de caja actualizado.");
        }

        private void Eliminar()
        {
            Console.Write("ID del movimiento a eliminar: ");
            int id = int.Parse(Console.ReadLine());
            _service.Eliminar(id);
        }
    }
}
