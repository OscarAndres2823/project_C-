namespace MiniprojectC_.domain.Entities;

public class Tercero
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellidos { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int TipoDocumentoId { get; set; }
    public int TipoTerceroId { get; set; }
    public int CiudadId { get; set; }
}
