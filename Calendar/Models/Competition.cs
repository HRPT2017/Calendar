namespace Calendar.Models
{
    public class Competition
    {
        public int id { get; set; }
        public required string name { get; set; }

        public required int modalityId { get; set; }

        public required string badge { get; set; }
        public Modality? modality { get; set; }



        public virtual ICollection<EventCompetition> ? eventCompetition { get; set; }


    }
}
