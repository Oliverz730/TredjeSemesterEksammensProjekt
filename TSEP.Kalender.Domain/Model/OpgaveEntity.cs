using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSEP.Kalender.Domain.Model
{
    public class OpgaveEntity
    {
        public int ProjektId { get; private set; }
        public int OpgaveTypeId { get; private set; }
        public int AnsatId { get; private set; }
        public string Status { get; private set; }
        public DateTime StartTid { get; private set; }
        public DateTime SlutTid { get; private set; }

        [Timestamp]
        public byte[] RowVersion { get; private set; }

        //EF
        internal OpgaveEntity() { }

        public OpgaveEntity(int projektId, int opgaveTypeId, int ansatId, string status, DateTime startTid, DateTime slutTid)
        {
            ProjektId = projektId;
            OpgaveTypeId = opgaveTypeId;
            AnsatId = ansatId;
            Status = status;
            StartTid = startTid;
            SlutTid = slutTid;
        }
    }
}
