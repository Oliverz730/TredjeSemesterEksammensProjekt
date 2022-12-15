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
            //tilføj opgave til databasen
            _db.OpgaveTypeEntities.Add(opgaveTypeEntity);
            //gem ændringer i databasen
            _db.SaveChanges();
        }

        OpgaveTypeQueryResultDto IOpgaveTypeRepository.Get(int id)
        {
            //indlæs opgavetype baseret på id
            var opgaveType = _db.OpgaveTypeEntities.AsNoTracking().First(o => o.Id == id);
            // Hvis ikke opgave type eksistere i databasen, throw exception ""
            if (opgaveType == null) throw new Exception("Opgave med givne id findes ikke");

            //konverter fra entitet til dto
            return new OpgaveTypeQueryResultDto
            {
                KompetanceId = opgaveType.KompetanceId,
                Beskrivelse = opgaveType.Beskrivelse,
                Id = opgaveType.Id,
                RowVersion = opgaveType.RowVersion
            };
        }

        IEnumerable<OpgaveTypeQueryResultDto> IOpgaveTypeRepository.GetAll()
        {
            //Iterer over opgavetype liste i databasen
            foreach (var opgaveType in _db.OpgaveTypeEntities.AsNoTracking().ToList())
            {
                //konverter fra entitet tilopgavetypeDto, og yield hver enkeltvis
                yield return new OpgaveTypeQueryResultDto
                {
                    Id = opgaveType.Id,
                    Beskrivelse = opgaveType.Beskrivelse,
                    KompetanceId = opgaveType.KompetanceId,
                    RowVersion = opgaveType.RowVersion
                };
            }
        }

        OpgaveTypeEntity IOpgaveTypeRepository.Load(int id)
        {
            //Indlæs opgavetype pr id
            var opgaveType = _db.OpgaveTypeEntities.AsNoTracking().First(o => o.Id == id);
            // Hvis ikke opgave type eksistere i databasen, throw exception ""
            if (opgaveType == null) throw new Exception("Opgave med givne id findes ikke");

            //Returner fundne opgavetyper
            return opgaveType;
        }

        void IOpgaveTypeRepository.Update(OpgaveTypeEntity opgaveType)
        {
            //updater opgavetype i databasen
            _db.OpgaveTypeEntities.Update(opgaveType);
            //Gæm ændringer i databasen
            _db.SaveChanges();
        }
    }
}
