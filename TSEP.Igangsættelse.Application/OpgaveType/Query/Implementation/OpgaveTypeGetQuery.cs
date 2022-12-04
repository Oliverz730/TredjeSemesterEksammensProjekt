using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSEP.Igangsættelse.Application.OpgaveType.Repositories;

namespace TSEP.Igangsættelse.Application.OpgaveType.Query.Implementation
{
    public class OpgaveTypeGetQuery : IOpgaveTypeGetQuery
    {
        private readonly IOpgaveTypeRepository _opgaveRepository;
        public OpgaveTypeGetQuery(IOpgaveTypeRepository opgaveRepository)
        {
            _opgaveRepository = opgaveRepository;
        }

        OpgaveTypeQueryResultDto IOpgaveTypeGetQuery.Get(int id)
        {
            return _opgaveRepository.Get(id);
        }
    }
}
