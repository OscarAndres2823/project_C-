using System;

namespace MiniprojectC_.Domain
{
    public class DetalleVenta
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }

    public class Factura
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public int EmpleadoId { get; set; }
    }

    public class Compra
    {
        public int Id { get; set; }
        public int ProveedorId { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class DetalleCompra
    {
        public int Id { get; set; }
        public int CompraId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }

    public class TipoMovimientoCaja
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class PlanProducto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
