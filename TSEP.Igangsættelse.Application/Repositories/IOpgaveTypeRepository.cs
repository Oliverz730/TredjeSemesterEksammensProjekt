using TSEP.Igangsættelse.Domain.Model;

namespace TSEP.Igangsættelse.Application.Repositories
{
    public interface IOpgaveTypeRepository
    {
        void Add(OpgaveTypeEntity opgaveTypeEntity);
    }
}
