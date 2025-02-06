namespace Calendar.Models
{
    public class Modality
    {
        public int id { get; set; }
        public  required string name { get; set; }

        public virtual ICollection<Competition> ? competition{ get; set; }

        public virtual ICollection<Event> ? events { get; set; }

    }
}
