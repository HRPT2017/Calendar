namespace Calendar.Models
{
    public class EventCompetition
    {
        public int competitionId { get; set; }
        public int eventId { get; set; }

        public  virtual Competition ? competition { get; set; }

        public  virtual Event ? events { get; set; }


    }
}
