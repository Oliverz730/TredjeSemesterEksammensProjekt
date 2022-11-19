using Microsoft.EntityFrameworkCore;
using TSEP.SqlDbContext;
using TSEP.StamData.Application.Kompetance.Queries;
using TSEP.StamData.Application.Kompetance.Repositories;
using TSEP.StamData.Domain.Model;

namespace TSEP.StamData.Infrastructor.Repositories
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
            var kompetanceEntity = _db.KompetanceEntities.FirstOrDefault(x => x.Id == id);
            if (kompetanceEntity == null) throw new Exception("Kompetance findes ikke");

            return kompetanceEntity;
        }

        KompetanceQueryResultDto IKompetanceRepository.Get(int id)
        {
            var kompetanceEntity = _db.KompetanceEntities.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (kompetanceEntity == null) throw new Exception("Kompetance findes ikke");

            /*
            var ansatteDto = _db.KompetanceEntities.AsNoTracking().Where(k => k.Id == id).SelectMany(k => k.Ansatte).Select(a => new KompetanceAnsatQueryResultDto
            {
                UserId = a.UserId
            }).ToList();
            */

            return new KompetanceQueryResultDto
            {
                Id= kompetanceEntity.Id,
                Description = kompetanceEntity.Description,
                //Ansatte = ansatteDto
            };
        }

        void IKompetanceRepository.Update(KompetanceEntity kompetance)
        {
            _db.KompetanceEntities.Update(kompetance);
            _db.SaveChanges();
        }

        IEnumerable<KompetanceQueryResultDto> IKompetanceRepository.GetAll()
        {
            foreach(var entity in _db.KompetanceEntities.AsNoTracking().ToList())
            {
                //var ansatte = entity.Ansatte.Select(a => new KompetanceAnsatQueryResultDto { UserId = a.UserId});
                yield return new KompetanceQueryResultDto { Description = entity.Description, Id = entity.Id };
            }
        }
    }
}
