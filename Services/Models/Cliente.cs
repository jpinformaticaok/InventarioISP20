namespace Services.Models
{
    public class Cliente
    {
        public int? Id { get; set; }
        public DateTimeOffset? Created_at { get; set; } = DateTimeOffset.Now;
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } =  string.Empty;
        public string Dni { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int LocalidadId { get; set; } = 0;
        public Localidad? Localidad { get; set; }
        public bool isDeleted { get; set; } = false;
    }
}
