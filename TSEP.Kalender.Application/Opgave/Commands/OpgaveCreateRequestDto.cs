using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSEP.Kalender.Application.Opgave.Commands
{
    public class OpgaveCreateRequestDto
    {
        public int ProjektId { get; set; }
        public int OpgaveTypeId { get; set; }
        public string AnsatId { get; set; }
        public string Status { get; set; }
        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }
    }
}
