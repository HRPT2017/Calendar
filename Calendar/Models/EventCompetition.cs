using System.ComponentModel.DataAnnotations.Schema;

namespace Calendar.Models
{
    public class EventCompetition
    {
        public int competitionId { get; set; }
        public int eventId { get; set; }

        [ForeignKey("competitionId")]
        public  virtual Competition ? competition { get; set; }

        [ForeignKey("eventId")]
        public  virtual Event ? events { get; set; }


    }
}
