using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSEP.Igangsættelse.Application.Projekt.Commands
{
    public interface IProjektEditCommand
    {
        void Edit(ProjektEditRequestDto projektEditRequestDto);
    }
}
