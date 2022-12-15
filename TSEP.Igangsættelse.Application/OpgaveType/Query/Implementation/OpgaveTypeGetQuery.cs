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
            //returner den fundne dto fra repository
            return _opgaveRepository.Get(id);
        }
    }
}
