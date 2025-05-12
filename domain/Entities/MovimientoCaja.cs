public class MovimientoCaja
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public int TipoMovimientoCajaId { get; set; }
    public decimal Monto { get; set; }
    public string Descripcion { get; set; }
    public int TerceroId { get; set; }  
    
}
