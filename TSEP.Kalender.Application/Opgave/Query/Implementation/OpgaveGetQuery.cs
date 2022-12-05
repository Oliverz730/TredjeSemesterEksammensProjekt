using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSEP.Kalender.Application.Opgave.Repositories;

namespace TSEP.Kalender.Application.Opgave.Query.Implementation
{
    public class OpgaveGetQuery : IOpgaveGetQuery
    {
        private readonly IOpgaveRepository _opgaveRepository;

        public OpgaveGetQuery(IOpgaveRepository opgaveRepository)
        {
            _opgaveRepository = opgaveRepository;
        }

        OpgaveQueryResultDto IOpgaveGetQuery.Get(int projektId, int opgaveTypeId, int ansatId)
        {
            return _opgaveRepository.Get(projektId, opgaveTypeId, ansatId);
        }
    }
}
