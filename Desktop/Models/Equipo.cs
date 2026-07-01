namespace Desktop.Models
{
    public class Equipo
    {
        public int? id_equipo { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string numero_serie { get; set; }
        public DateTime? created_at { get; set; }
        public long id_tipo_equipo { get; set; }
    }
}
