namespace MiniprojectC_.Domain
{
    public class Ciudad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int RegionId { get; set; }  // Relación con la tabla Región
    }
}
