namespace Calendar.Models
{
    public class Modalidade
    {
        public int Id { get; set; }
        public  required string Nome { get; set; }

        public virtual ICollection<Competicao> ? Competicao { get; set; }

        public virtual ICollection<Evento> ? Evento { get; set; }

    }
}
