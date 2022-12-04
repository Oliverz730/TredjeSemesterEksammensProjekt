using TSEP.Igangsættelse.Domain.Model;

namespace TSEP.Igangsættelse.Application.OpgaveType.Repositories
{
    public interface IOpgaveTypeRepository
    {
        void Add(OpgaveTypeEntity opgaveTypeEntity);
    }
}
