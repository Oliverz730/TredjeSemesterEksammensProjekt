using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TredjeSemesterEksamensProjekt.Opgave.Application.Queries
{
    public class KompetanceQueryResultDto
    {
        public string Description { get; set; }
        public ICollection<KompetanceAnsatQueryResultDto> Ansatte { get; set; }
    }
}
