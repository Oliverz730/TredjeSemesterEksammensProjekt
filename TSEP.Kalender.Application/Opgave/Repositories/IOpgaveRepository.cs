using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSEP.Kalender.Application.Opgave.Query;
using TSEP.Kalender.Domain.Model;

namespace TSEP.Kalender.Application.Opgave.Repositories
{
    public interface IOpgaveRepository
    {
        void Add(OpgaveEntity opgave);
        OpgaveQueryResultDto Get(int projektId, int opgaveTypeId, int ansatId);
        IEnumerable<OpgaveQueryResultDto> GetAllByProjekt(int projektId);
        IEnumerable<OpgaveQueryResultDto> GetAllByAnsat(int ansatId);
    }
}
