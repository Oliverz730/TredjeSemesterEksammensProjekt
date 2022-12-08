using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSEP.Igangsættelse.Domain.Model;
using TSEP.Igangsættelse.Application.OpgaveType.Repositories;

namespace TSEP.Igangsættelse.Application.OpgaveType.Query.Implementation
{
    public class OpgaveTypeGetAllQuery : IOpgaveTypeGetAllQuery
    {
        private readonly IOpgaveTypeRepository _opgaveTypeRepository;

        public OpgaveTypeGetAllQuery(IOpgaveTypeRepository opgaveTypeRepository)
        {
            _opgaveTypeRepository = opgaveTypeRepository;
        }

        IEnumerable<OpgaveTypeQueryResultDto> IOpgaveTypeGetAllQuery.GetAll()
        {
            return _opgaveTypeRepository.GetAll();
        }
    }
}
