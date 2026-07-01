namespace Desktop.Models
{
    public class Cliente
    {
        public int? id { get; set; }
        public DateTime? created_at { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string dni { get; set; }
        public string address { get; set; }
    }
}
