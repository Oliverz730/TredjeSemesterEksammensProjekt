using System.ComponentModel.DataAnnotations;


namespace TSEP.Kalender.Domain.Model
{
    public class OpgaveEntity
    {
        public int ProjektId { get; private set; }
        public int OpgaveTypeId { get; private set; }
        public string AnsatId { get; private set; }
        public string Status { get; private set; }
        public DateTime StartTid { get; private set; }
        public DateTime SlutTid { get; private set; }
        //Hvis Timestamp (RowVersion) tabes under roundtrip, vil man ikke få lov til at edit.
        [Timestamp]
        public byte[] RowVersion { get; private set; }

        //EF
        internal OpgaveEntity() { }

        public OpgaveEntity(int projektId, int opgaveTypeId, string ansatId, string status, DateTime startTid, DateTime slutTid)
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
