using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSEP.Kalender.Application.Opgave.Repositories;

namespace TSEP.Kalender.Application.Opgave.Query.Implementation
{
    public class OpgaveGetAllQuery : IOpgaveGetAllQuery
    {
        private readonly IOpgaveRepository _opgaveRepository;

        public OpgaveGetAllQuery(IOpgaveRepository opgaveRepository)
        {
            _opgaveRepository = opgaveRepository;
        }

        IEnumerable<OpgaveQueryResultDto> IOpgaveGetAllQuery.GetAllByAnsat(string ansatId)
        {
            //Return de fundne opgavedto med givne ansatId fra repository
            return _opgaveRepository.GetAllByAnsat(ansatId);
        }

        IEnumerable<OpgaveQueryResultDto> IOpgaveGetAllQuery.GetAllByProjekt(int projektId)
        {
            //Return de fundne opgavedto med givne projektid fra repository
            return _opgaveRepository.GetAllByProjekt(projektId);
        }
    }
}
