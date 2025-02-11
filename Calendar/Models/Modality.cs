using System.ComponentModel.DataAnnotations;

namespace Calendar.Models
{
    public class Modality
    {
        [Key]
        public int id { get; set; }
        public  required string name { get; set; }

        public virtual ICollection<Competition> ? competition{ get; set; }

        public virtual ICollection<Event> ? events { get; set; }

    }
}
