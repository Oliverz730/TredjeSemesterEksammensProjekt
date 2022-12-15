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
            //Return de fundne opgaveTypedto fra repository
            return _opgaveTypeRepository.GetAll();
        }
    }
}
