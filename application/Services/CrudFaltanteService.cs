using System;
using System.Collections.Generic;
using MiniprojectC_.Domain;

namespace MiniprojectC_.Application.Services
{
    public class CrudFaltanteService
    {
        public List<DetalleVenta> DetalleVentas { get; } = new();
        public List<Factura> Facturas { get; } = new();
        public List<Compra> Compras { get; } = new();
        public List<DetalleCompra> DetalleCompras { get; } = new();
        public List<TipoMovimientoCaja> TiposMovimientoCaja { get; } = new();
        public List<PlanProducto> PlanesProducto { get; } = new();

        public void Crear<T>(List<T> lista, T entidad)
        {
            lista.Add(entidad);
        }

        public List<T> ObtenerTodos<T>(List<T> lista)
        {
            return lista;
        }

        public void Eliminar<T>(List<T> lista, Predicate<T> predicado)
        {
            var entidad = lista.Find(predicado);
            if (entidad != null) lista.Remove(entidad);
        }

        // TipoMovimientoCaja
        public void AgregarTipoMovimientoCaja(string nombre)
        {
            var tipo = new TipoMovimientoCaja { Id = TiposMovimientoCaja.Count + 1, Nombre = nombre };
            Crear(TiposMovimientoCaja, tipo);
        }

        public void ListarTipoMovimientoCaja()
        {
            foreach (var tipo in TiposMovimientoCaja)
                Console.WriteLine($"ID: {tipo.Id}, Nombre: {tipo.Nombre}");
        }

        public void EditarTipoMovimientoCaja(int id, string nuevoNombre)
        {
            var tipo = TiposMovimientoCaja.Find(t => t.Id == id);
            if (tipo != null) tipo.Nombre = nuevoNombre;
        }

        public void EliminarTipoMovimientoCaja(int id)
        {
            Eliminar(TiposMovimientoCaja, t => t.Id == id);
        }

        // PlanProducto
        public void AgregarPlanProducto(string nombre, string descripcion)
        {
            var plan = new PlanProducto { Id = PlanesProducto.Count + 1, Nombre = nombre, Descripcion = descripcion };
            Crear(PlanesProducto, plan);
        }

        public void ListarPlanProducto()
        {
            foreach (var plan in PlanesProducto)
                Console.WriteLine($"ID: {plan.Id}, Nombre: {plan.Nombre}, Descripción: {plan.Descripcion}");
        }

        public void EditarPlanProducto(int id, string nuevoNombre, string nuevaDescripcion)
        {
            var plan = PlanesProducto.Find(p => p.Id == id);
            if (plan != null)
            {
                plan.Nombre = nuevoNombre;
                plan.Descripcion = nuevaDescripcion;
            }
        }

        public void EliminarPlanProducto(int id)
        {
            Eliminar(PlanesProducto, p => p.Id == id);
        }

        // DetalleVenta
        public void AgregarDetalleVenta(int productoId, int cantidad, decimal precioUnitario)
        {
            var detalle = new DetalleVenta
            {
                Id = DetalleVentas.Count + 1,
                ProductoId = productoId,
                Cantidad = cantidad,
                PrecioUnitario = precioUnitario
            };
            Crear(DetalleVentas, detalle);
        }

        public void ListarDetalleVenta()
        {
            foreach (var d in DetalleVentas)
                Console.WriteLine($"ID: {d.Id}, ProductoId: {d.ProductoId}, Cantidad: {d.Cantidad}, Precio Unitario: {d.PrecioUnitario}");
        }

        public void EditarDetalleVenta(int id, int productoId, int cantidad, decimal precioUnitario)
        {
            var d = DetalleVentas.Find(x => x.Id == id);
            if (d != null)
            {
                d.ProductoId = productoId;
                d.Cantidad = cantidad;
                d.PrecioUnitario = precioUnitario;
            }
        }

        public void EliminarDetalleVenta(int id)
        {
            Eliminar(DetalleVentas, d => d.Id == id);
        }

        // Factura
        public void AgregarFactura(DateTime fecha, int clienteId, int empleadoId)
        {
            var factura = new Factura
            {
                Id = Facturas.Count + 1,
                Fecha = fecha,
                ClienteId = clienteId,
                EmpleadoId = empleadoId
            };
            Crear(Facturas, factura);
        }

        public void ListarFactura()
        {
            foreach (var f in Facturas)
                Console.WriteLine($"ID: {f.Id}, Fecha: {f.Fecha.ToShortDateString()}, ClienteId: {f.ClienteId}, EmpleadoId: {f.EmpleadoId}");
        }

        public void EditarFactura(int id, DateTime nuevaFecha, int nuevoClienteId, int nuevoEmpleadoId)
        {
            var f = Facturas.Find(f => f.Id == id);
            if (f != null)
            {
                f.Fecha = nuevaFecha;
                f.ClienteId = nuevoClienteId;
                f.EmpleadoId = nuevoEmpleadoId;
            }
        }

        public void EliminarFactura(int id)
        {
            Eliminar(Facturas, f => f.Id == id);
        }

        // Compra
        public void AgregarCompra(int proveedorId, DateTime fecha)
        {
            var compra = new Compra
            {
                Id = Compras.Count + 1,
                ProveedorId = proveedorId,
                Fecha = fecha
            };
            Crear(Compras, compra);
        }

        public void ListarCompra()
        {
            foreach (var c in Compras)
                Console.WriteLine($"ID: {c.Id}, ProveedorId: {c.ProveedorId}, Fecha: {c.Fecha.ToShortDateString()}");
        }

        public void EditarCompra(int id, int nuevoProveedorId, DateTime nuevaFecha)
        {
            var c = Compras.Find(c => c.Id == id);
            if (c != null)
            {
                c.ProveedorId = nuevoProveedorId;
                c.Fecha = nuevaFecha;
            }
        }

        public void EliminarCompra(int id)
        {
            Eliminar(Compras, c => c.Id == id);
        }

        // DetalleCompra (incluye CompraId)
        public void AgregarDetalleCompra(int compraId, int productoId, int cantidad, decimal precioUnitario)
        {
            var detalle = new DetalleCompra
            {
                Id = DetalleCompras.Count + 1,
                CompraId = compraId,
                ProductoId = productoId,
                Cantidad = cantidad,
                PrecioUnitario = precioUnitario
            };
            Crear(DetalleCompras, detalle);
        }

        public void ListarDetalleCompra()
        {
            foreach (var d in DetalleCompras)
                Console.WriteLine($"ID: {d.Id}, CompraId: {d.CompraId}, ProductoId: {d.ProductoId}, Cantidad: {d.Cantidad}, Precio Unitario: {d.PrecioUnitario}");
        }

        public void EditarDetalleCompra(int id, int nuevoCompraId, int nuevoProductoId, int nuevaCantidad, decimal nuevoPrecioUnitario)
        {
            var d = DetalleCompras.Find(d => d.Id == id);
            if (d != null)
            {
                d.CompraId = nuevoCompraId;
                d.ProductoId = nuevoProductoId;
                d.Cantidad = nuevaCantidad;
                d.PrecioUnitario = nuevoPrecioUnitario;
            }
        }

        public void EliminarDetalleCompra(int id)
        {
            Eliminar(DetalleCompras, d => d.Id == id);
        }
    }
}
