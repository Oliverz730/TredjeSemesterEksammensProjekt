using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TredjeSemesterEksamensProjekt.Opgave.Application.Commands
{
    public interface IKompetanceEditCommand
    {
        void Edit(KompetanceEditRequestDto kompetanceEditRequestDto);

    }
}
