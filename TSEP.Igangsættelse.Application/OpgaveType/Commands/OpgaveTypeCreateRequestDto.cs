using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSEP.Igangsættelse.Application.OpgaveType.Commands
{
    public class OpgaveTypeCreateRequestDto
    {
        public string Beskrivelse { get; private set; }

        public int KompetanceId { get; private set; }
    }
}
