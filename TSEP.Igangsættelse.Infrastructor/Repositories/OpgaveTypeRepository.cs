using Microsoft.EntityFrameworkCore;
using TSEP.Igangsættelse.Application.OpgaveType.Query;
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

        OpgaveTypeQueryResultDto IOpgaveTypeRepository.Get(int id)
        {
            var opgaveType = _db.OpgaveTypeEntities.AsNoTracking().First(o => o.Id == id);
            if (opgaveType == null) throw new Exception("Opgave med givne id findes ikke");


            return new OpgaveTypeQueryResultDto
            {
                KompetanceId = opgaveType.KompetanceId,
                Beskrivelse = opgaveType.Beskrivelse,
                Id = opgaveType.Id,
                RowVersion = opgaveType.RowVersion
            };
        }

        OpgaveTypeEntity IOpgaveTypeRepository.Load(int id)
        {
            var opgaveType = _db.OpgaveTypeEntities.AsNoTracking().First(o => o.Id == id);
            if (opgaveType == null) throw new Exception("Opgave med givne id findes ikke");

            return opgaveType;
        }

        void IOpgaveTypeRepository.Update(OpgaveTypeEntity opgaveType)
        {
            _db.OpgaveTypeEntities.Update(opgaveType);
            _db.SaveChanges();
        }
    }
}
