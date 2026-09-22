using System.ComponentModel;

namespace Services.Models
{
    public class Cliente
    {
        [Browsable(false)]
        public int? Id { get; set; }
        [DisplayName("Fecha de creación")]
        public DateTimeOffset? Created_at { get; set; } = DateTimeOffset.UtcNow;
        [DisplayName("Nombres")]
        public string Firstname { get; set; } = string.Empty;
        [DisplayName("Apellidos")]
        public string Lastname { get; set; } =  string.Empty;
        public string Dni { get; set; } = string.Empty;
        [DisplayName("Dirección")]
        public string Address { get; set; } = string.Empty;
        [Browsable(false)]
        public int LocalidadId { get; set; } = 0;
        public Localidad? Localidad { get; set; }
        [Browsable(false)]
        public bool isDeleted { get; set; } = false;
    }
}
