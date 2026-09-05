namespace Services.Models
{
    public class Provincia
    {
        public int? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int PaisId { get; set; } = 0;
        public Pais? Pais { get; set; } = null;
        public bool isDeleted { get; set; } = false;
    }
}
