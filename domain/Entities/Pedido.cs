using System;

namespace MiniprojectC_.domain.Entities;

public class Pedido
{
    public int Id { get; set; }
    public int FacturaId { get; set; }
    public DateTime Fecha { get; set; }
    public int EmpleadoId { get; set; }
    public int ClienteId { get; set; }
}
