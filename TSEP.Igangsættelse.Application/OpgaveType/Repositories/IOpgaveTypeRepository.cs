using TSEP.Igangsættelse.Application.OpgaveType.Query;
using TSEP.Igangsættelse.Domain.Model;

namespace TSEP.Igangsættelse.Application.OpgaveType.Repositories
{
    public interface IOpgaveTypeRepository
    {
        void Add(OpgaveTypeEntity opgaveType);
        OpgaveTypeEntity Load(int id);
        void Update(OpgaveTypeEntity opgaveType);
        OpgaveTypeQueryResultDto Get(int id);
    }
}
