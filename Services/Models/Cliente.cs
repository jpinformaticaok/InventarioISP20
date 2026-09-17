using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        [DisplayName("Apellido")]
        public string Lastname { get; set; } =  string.Empty;
        public string Dni { get; set; } = string.Empty;
        [DisplayName("Dirección")]
        public string Address { get; set; } = string.Empty;

        [Browsable(false)] // <--- Esto le dice al DataGridView que la ignore por completo
        public int LocalidadId { get; set; } = 0;
        public Localidad? Localidad { get; set; }

        [Browsable(false)] // <--- Esto le dice al DataGridView que la ignore por completo
        public bool isDeleted { get; set; } = false;
    }
}
