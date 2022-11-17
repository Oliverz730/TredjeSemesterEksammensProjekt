using TredjeSemesterEksamensProjekt.Opgave.Application.Repositories;
using TredjeSemesterEksamensProjekt.Opgave.Domain.Model;
using TredjeSemesterEksamensProjekt.SqlDbContextProjekt;
using Microsoft.EntityFrameworkCore;
using TredjeSemesterEksamensProjekt.Opgave.Application.Queries;

namespace TredjeSemesterEksamensProjekt.Opgave.Infrastructor.Repositories
{
    public class KompetanceRepository : IKompetanceRepository
    {
        private readonly TredjeSemesterEksamensProjektContext _db;

        public KompetanceRepository(TredjeSemesterEksamensProjektContext db)
        {
            _db = db;
        }

        void IKompetanceRepository.Add(KompetanceEntity kompetance)
        {
            _db.KompetanceEntities.Add(kompetance);
            _db.SaveChanges();
        }

        KompetanceEntity IKompetanceRepository.Load(int id)
        {
            var kompetanceEntity = _db.KompetanceEntities.AsNoTracking().Include(k => k.Ansatte).FirstOrDefault(x => x.Id == id);
            if (kompetanceEntity == null) throw new Exception("Kompetance findes ikke");

            return kompetanceEntity;
        }

        KompetanceQueryResultDto IKompetanceRepository.Get(int id)
        {
            var kompetanceEntity = _db.KompetanceEntities.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (kompetanceEntity == null) throw new Exception("Kompetance findes ikke");

            var ansatteDto = _db.KompetanceEntities.AsNoTracking().Where(k => k.Id == id).SelectMany(k => k.Ansatte).Select(a => new KompetanceAnsatQueryResultDto
            {
                UserId = a.UserId
            }).ToList();

            return new KompetanceQueryResultDto
            {
                Description = kompetanceEntity.Description,
                Ansatte = ansatteDto
            };
        }
    }
}
