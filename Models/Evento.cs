using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }

        public int Modalidade_Id { get; set; }
        public Modalidade Modalidade { get; set; }


        public virtual ICollection<JunctionTable> JunctionTable { get; set; }
    }
}
