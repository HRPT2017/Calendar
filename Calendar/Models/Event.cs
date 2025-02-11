using System.ComponentModel.DataAnnotations.Schema;

namespace Calendar.Models
{
    public class Event
    {
        public int id { get; set; }
        public required string name { get; set; }
        public DateTime startDate { get; set; }

        public DateTime? endDate { get; set; }

        public required int modalityId { get; set; }

        [ForeignKey("modalityId")]
        public Modality ? modality { get; set; }


        public virtual ICollection<EventCompetition> ? eventConpetition { get; set; }
    }
}
