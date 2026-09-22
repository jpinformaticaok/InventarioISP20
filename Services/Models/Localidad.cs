using System.ComponentModel;

namespace Services.Models
{
    public class Localidad
    {
        [Browsable(false)]
        public int Id { get; set; } = 0;
        [DisplayName("Nombre de la localidad")]
        public string Name { get; set; } = string.Empty;
        [Browsable(false)]
        public int ProvinciaId { get; set; } = 0;
        public Provincia? Provincia { get; set; } = null;
        [Browsable(false)]
        public bool isDeleted { get; set; } = false;

        public override string ToString()
        {
            return Name;
        }

    }
}
