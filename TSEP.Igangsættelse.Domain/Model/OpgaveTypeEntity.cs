using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSEP.Igangsættelse.Domain.Model
{
    public class OpgaveTypeEntity
    {
        public int Id { get; private set; }
        public string Beskrivelse { get; private set; }

        public int KompetanceId { get; private set; }
        [Timestamp]
        public byte[] RowVersion { get; private set; }

        //EF
        internal OpgaveTypeEntity() { }

        public OpgaveTypeEntity(string beskrivelse, int kompetanceId, byte[] rowVersion)
        {
            Beskrivelse = beskrivelse;
            KompetanceId = kompetanceId;
            RowVersion = rowVersion;
        }
    }
}
