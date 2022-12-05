using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSEP.Kalender.Application.Opgave.Commands
{
    public interface IOpgaveCreateCommand
    {
        void Create(OpgaveCreateRequestDto opgaveCreateRequestDto);
    }
}
