using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSEP.Igangsættelse.Application.OpgaveType.Commands
{
    public class OpgaveTypeEditRequestDto
    {
        public int Id { get; private set; }
        public string Beskrivelse { get; private set; }

        public int KompetanceId { get; private set; }
        public byte[] RowVersion { get; private set; }
    }
}
