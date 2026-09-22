using System.ComponentModel;

namespace Services.Models
{
    public class Pais
    {
        [Browsable(false)]
        public int? Id { get; set; }
        [DisplayName("Nombre del Pais")]
        public string Name { get; set; } = string.Empty;
        [Browsable(false)]
        public bool isDeleted { get; set; } = false;

        public override string ToString()
        {
            return Name;
        }
    }
}