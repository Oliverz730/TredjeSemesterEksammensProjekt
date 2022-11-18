using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TredjeSemesterEksamensProjekt.Opgave.Application.Commands
{
    public class AnsatEditRequestDto
    {
        public string UserId { get; set; }
        public string Name { get; set; }

        public ICollection<AnsatKompetanceEditRequestDto> Kompetancer { get; set; }

    }
}
