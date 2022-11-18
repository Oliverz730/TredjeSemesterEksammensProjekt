using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TredjeSemesterEksamensProjekt.Opgave.Domain.Model;

namespace TredjeSemesterEksamensProjekt.Opgave.Application.Queries
{
    public class AnsatQueryResultDto
    {
        public string Name { get; set; }
        public ICollection<AnsatKompetanceQueryResultDto> Kompetancer { get; set; }

        public string UserId { get; set; }
    }
}
