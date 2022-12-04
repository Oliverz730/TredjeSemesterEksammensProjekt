using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSEP.Igangsættelse.Application.OpgaveType.Query
{
    public interface IOpgaveTypeGetQuery
    {
        OpgaveTypeQueryResultDto Get(int id);
    }
}
