using System;

namespace MiniprojectC_.domain.Entities;

public class Producto
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public int Stock { get; set; }
    public int StockMinimo { get; set; }
    public int StockMaximo { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string? BarCode { get; set; }
}
