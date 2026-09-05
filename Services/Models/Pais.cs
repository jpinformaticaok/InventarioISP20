namespace Services.Models
{
    public class Pais
    {
        public int? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool isDeleted { get; set; } = false;
    }
}