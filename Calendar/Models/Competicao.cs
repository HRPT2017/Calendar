using Calendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Models
{
    public class Competicao
    {
        public int Id { get; set; }
        public required string Nome { get; set; }

        public required int Modalidade_Id { get; set; }

        public  Modalidade ? Modalidade { get; set; }


        public virtual ICollection<JunctionTable> ? JunctionTable { get; set; }


    }
}
