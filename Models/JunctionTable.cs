using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Models
{
    public class JunctionTable
    {
        public int Competicao_Id { get; set; }
        public int Evento_Id { get; set; }

        public virtual Competicao Competicao { get; set; }

        public virtual Evento Evento { get; set; }


    }
}
