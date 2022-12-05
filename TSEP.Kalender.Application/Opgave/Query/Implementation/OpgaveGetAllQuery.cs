using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSEP.Kalender.Application.Opgave.Repositories;

namespace TSEP.Kalender.Application.Opgave.Query.Implementation
{
    internal class OpgaveGetAllQuery : IOpgaveGetAllQuery
    {
        private readonly IOpgaveRepository _opgaveRepository;

        public OpgaveGetAllQuery(IOpgaveRepository opgaveRepository)
        {
            _opgaveRepository = opgaveRepository;
        }

        IEnumerable<OpgaveQueryResultDto> IOpgaveGetAllQuery.GetAll(int projektId)
        {
            return _opgaveRepository.GetAll(projektId);
        }
    }
}
