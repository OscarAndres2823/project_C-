using System;

namespace MiniprojectC_.domain.Entities;

public class DetallePedido
{
    public int Id { get; set; }
    public int FacturaId { get; set; }
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
    public decimal Valor { get; set; }
}
