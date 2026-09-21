using System.ComponentModel;

namespace Services.Models
{
    public class Provincia
    {
        [Browsable(false)]
        public int? Id { get; set; }
        [DisplayName("Nombre de provincia")]
        public string Name { get; set; } = string.Empty;
        [Browsable(false)]
        public int PaisId { get; set; } = 0;
        public Pais? Pais { get; set; } = null;
        [Browsable(false)]
        public bool isDeleted { get; set; } = false;

        public override string ToString()
        {
            return Name;
        }
    }
}
