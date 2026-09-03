
namespace Services.Models
{
    public class Localidad
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;

        public int ProvinciaId { get; set; } = 0;
        public Provincia? Provincia { get; set; } = null;
        public bool isDeleted { get; set; } = false;
    }
}
