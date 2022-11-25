using System;
using System.Collections.Generic;
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

        //EF
        internal OpgaveTypeEntity() { }

        public OpgaveTypeEntity(string beskrivelse, int kompetanceId)
        {
            Beskrivelse = beskrivelse;
            KompetanceId = kompetanceId;
        }
    }
}
