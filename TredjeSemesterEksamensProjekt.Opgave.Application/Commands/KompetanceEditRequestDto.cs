using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TredjeSemesterEksamensProjekt.Opgave.Application.Commands
{
    public class KompetanceEditRequestDto
    {
        public string Description { get; set; }
        public ICollection<KompetanceAnsatEditRequestDto> Ansatte { get; set; }
    }
}
