namespace Calendar.Models
{
    public class JunctionTable
    {
        public int Competicao_Id { get; set; }
        public int Evento_Id { get; set; }

        public  virtual Competicao ?Competicao { get; set; }

        public  virtual Evento ?Evento { get; set; }


    }
}
