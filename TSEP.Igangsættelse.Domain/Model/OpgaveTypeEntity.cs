using System.ComponentModel.DataAnnotations;

namespace TSEP.Igangsættelse.Domain.Model
{
    public class OpgaveTypeEntity
    {
        public int Id { get; private set; }
        public string Beskrivelse { get; private set; }

        public int KompetanceId { get; private set; }
        //Hvis Timestamp (RowVersion) tabes under roundtrip, vil man ikke få lov til at edit.
        [Timestamp]
        public byte[] RowVersion { get; private set; }

        //EF
        internal OpgaveTypeEntity() { }
        
        public OpgaveTypeEntity(string beskrivelse, int kompetanceId)
        {
            Beskrivelse = beskrivelse;
            KompetanceId = kompetanceId;
        }

        public void Edit(string beskrivelse, int kompetanceId, byte[] rowVersion)
        {
            Beskrivelse = beskrivelse;
            KompetanceId = kompetanceId;
            RowVersion = rowVersion;
        }
    }
}
