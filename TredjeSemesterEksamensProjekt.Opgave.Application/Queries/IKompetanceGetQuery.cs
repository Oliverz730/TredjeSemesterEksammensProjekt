using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TredjeSemesterEksamensProjekt.Opgave.Application.Queries
{
    public interface IKompetanceGetQuery
    {
        KompetanceQueryResultDto Get(int id);
    }
}
