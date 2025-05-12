using System;
using System.Collections.Generic;
using MiniprojectC_.Domain;

namespace MiniprojectC_.Application.Services
{
    public class MovimientoCajaService
    {
        private readonly List<MovimientoCaja> _movimientos;

        public MovimientoCajaService()
        {
            // Inicialización de la lista de movimientos. Aquí puede ser una base de datos real en producción.
            _movimientos = new List<MovimientoCaja>();
        }

        public void Crear(MovimientoCaja movimiento)
        {
            // Verificación si ya existe un movimiento con el mismo ID.
            var movimientoExistente = _movimientos.Find(m => m.Id == movimiento.Id);
            if (movimientoExistente != null)
            {
                Console.WriteLine("Ya existe un movimiento con el mismo ID.");
                return;
            }

            _movimientos.Add(movimiento);
            Console.WriteLine("Movimiento de caja creado exitosamente.");
        }

        public List<MovimientoCaja> ObtenerTodos()
        {
            // Devuelve todos los movimientos de caja
            return _movimientos;
        }

        public void Actualizar(MovimientoCaja movimiento)
        {
            var movimientoExistente = _movimientos.Find(m => m.Id == movimiento.Id);
            if (movimientoExistente != null)
            {
                // Actualiza los campos del movimiento encontrado
                movimientoExistente.Fecha = movimiento.Fecha;
                movimientoExistente.TipoMovimientoCajaId = movimiento.TipoMovimientoCajaId;
                movimientoExistente.Monto = movimiento.Monto;
                movimientoExistente.Descripcion = movimiento.Descripcion;
                Console.WriteLine("Movimiento de caja actualizado.");
            }
            else
            {
                Console.WriteLine("Movimiento no encontrado.");
            }
        }

        public void Eliminar(int id)
        {
            var movimiento = _movimientos.Find(m => m.Id == id);
            if (movimiento != null)
            {
                _movimientos.Remove(movimiento);
                Console.WriteLine("Movimiento de caja eliminado.");
            }
            else
            {
                Console.WriteLine("Movimiento no encontrado.");
            }
        }
    }
}
