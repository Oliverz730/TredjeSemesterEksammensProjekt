using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSEP.Kalender.Application.Opgave.Query
{
    public interface IOpgaveGetQuery
    {
        public OpgaveQueryResultDto Get(int projektId, int opgaveTypeId, int ansatId);
    }
}
