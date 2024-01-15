using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Calendar.Models
{
    public class Modalidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Competicao> Competicao { get; set; }

        public virtual ICollection<Evento> Evento { get; set; }

    }
}
