using TSEP.Igangsættelse.Application.OpgaveType.Repositories;
using TSEP.Igangsættelse.Domain.Model;
using TSEP.SqlDbContext;

namespace TSEP.Igangsættelse.Infrastructor.Repositories
{
    public class OpgaveTypeRepository : IOpgaveTypeRepository
    {
        private readonly TredjeSemesterEksamensProjektContext _db;

        public OpgaveTypeRepository(TredjeSemesterEksamensProjektContext db)
        {
            _db = db;
        }

        void IOpgaveTypeRepository.Add(OpgaveTypeEntity opgaveTypeEntity)
        {
            _db.OpgaveTypeEntities.Add(opgaveTypeEntity);
            _db.SaveChanges();
        }
    }
}
