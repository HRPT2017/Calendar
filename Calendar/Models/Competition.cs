using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calendar.Models
{
    public class Competition
    {
        [Key]
        public int id { get; set; }
        public required string name { get; set; }

        public required int modalityId { get; set; }

        public required string badge { get; set; }

        [ForeignKey("modalityId")]
        public Modality? modality { get; set; }

        public virtual ICollection<EventCompetition> ? eventCompetition { get; set; }


    }
}
