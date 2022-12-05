using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSEP.Kalender.Application.Opgave.Query
{
    public class OpgaveQueryResultDto
    {
        public int ProjektId { get; private set; }
        public int OpgaveTypeId { get; private set; }
        public int AnsatId { get; private set; }
        public string Status { get; private set; }
        public DateTime StartTid { get; private set; }
        public DateTime SlutTid { get; private set; }
        public byte[] RowVersion { get; private set; }
    }
}
