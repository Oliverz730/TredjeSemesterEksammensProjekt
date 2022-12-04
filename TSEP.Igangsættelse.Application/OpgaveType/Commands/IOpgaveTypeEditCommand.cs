using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSEP.Igangsættelse.Application.OpgaveType.Commands
{
    public interface IOpgaveTypeEditCommand
    {
        void Edit(OpgaveTypeEditRequestDto opgaveType);
    }
}
