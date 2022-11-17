using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TredjeSemesterEksamensProjekt.Opgave.Application.Queries
{
    public interface IAnsatGetQuery
    {
        AnsatQueryResultDto Get(string UserId);
    }
}
