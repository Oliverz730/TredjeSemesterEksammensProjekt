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
            //Tilføj Kompetancen til databasen
            _db.KompetanceEntities.Add(kompetance);
            //Gem ændringerne i databasen
            _db.SaveChanges();
        }

        KompetanceEntity IKompetanceRepository.Load(int id)
        {
            //Find den Ansat med det givne userId
            var kompetanceEntity = _db.KompetanceEntities.FirstOrDefault(x => x.Id == id);

            //Hvis Kompetancen ikke findes, smid en exception
            if (kompetanceEntity == null) throw new Exception("Kompetance findes ikke");

            //Returnerer den fundne Kompetance
            return kompetanceEntity;
        }

        KompetanceQueryResultDto IKompetanceRepository.Get(int id)
        {
            //Indlæs data på Kompetancen baseret på dens Id
            var kompetanceEntity = _db.KompetanceEntities.AsNoTracking().FirstOrDefault(x => x.Id == id);
            
            //Hvis Kompetancen ikke blev fundet, smid en exception
            if (kompetanceEntity == null) throw new Exception("Kompetance findes ikke");

            //Konverter fra KompetanceEntity til KompetanceQueryResultDto
            return new KompetanceQueryResultDto
            {
                Id= kompetanceEntity.Id,
                Description = kompetanceEntity.Description,
                RowVersion = kompetanceEntity.RowVersion,
            };
        }

        void IKompetanceRepository.Update(KompetanceEntity kompetance)
        {
            //_db.KompetanceEntities.Update(kompetance);

            //Gem ændringer på Kompetancen 
            _db.SaveChanges();
        }

        IEnumerable<KompetanceQueryResultDto> IKompetanceRepository.GetAll()
        {
            //Iterer over listen af kompetanceEntity
            foreach(var entity in _db.KompetanceEntities.AsNoTracking().ToList())
            {
                //Konverter fra KompetanceEntity til KompetanceQueryResultDto, og yield hver enkeltvis
                yield return new KompetanceQueryResultDto { Description = entity.Description, Id = entity.Id,RowVersion = entity.RowVersion};
            }
        }
    }
}
