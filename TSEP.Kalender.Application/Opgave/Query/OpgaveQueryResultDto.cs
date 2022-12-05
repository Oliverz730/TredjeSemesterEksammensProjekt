using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSEP.Kalender.Application.Opgave.Query
{
    public class OpgaveQueryResultDto
    {
        public int ProjektId { get; set; }
        public int OpgaveTypeId { get; set; }
        public int AnsatId { get; set; }
        public string Status { get; set; }
        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
