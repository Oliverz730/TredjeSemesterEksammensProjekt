using Microsoft.EntityFrameworkCore;
using TSEP.SqlDbContext;
using TSEP.StamData.Application.Ansat.Queries;
using TSEP.StamData.Application.Ansat.Repositories;
using TSEP.StamData.Domain.Model;

namespace TSEP.StamData.Infrastructor.Repositories
{
    public class AnsatRepository : IAnsatRepository
    {
        private readonly TredjeSemesterEksamensProjektContext _db;

        public AnsatRepository(TredjeSemesterEksamensProjektContext db)
        {
            _db = db;
        }

        void IAnsatRepository.Add(AnsatEntity ansat)
        {
            //Tilføj den Ansatte til databasen
            _db.Add(ansat);
            //Gem ændringerne i databasen
            _db.SaveChanges();
        }

        AnsatQueryResultDto IAnsatRepository.Get(string userId)
        {
            //Indlæs data på den Ansatte baseret på deres userId
            var ansat = _db.AnsatEntities.AsNoTracking().Include(a => a.Kompetancer).FirstOrDefault(a => a.UserId == userId);
            
            //Hvis den Ansatte ikke blev fundet, smid en exception
            if (ansat == null) throw new Exception("Ansat Findes ikke");
            
            //Konverter fra KompetanceEntity til AnsatKompetanceQueryResultDto
            var kompetancer = ansat.Kompetancer.Select(k => new AnsatKompetanceQueryResultDto { Description = k.Description, Id = k.Id, RowVersion = k.RowVersion}).ToList();

            //Konverter fra AnsatEntity til AnsatQueryResultDto
            return new AnsatQueryResultDto
            {
                Name = ansat.Name,
                UserId = ansat.UserId,
                Kompetancer = kompetancer,
                RowVersion = ansat.RowVersion,
            };

        }

        IEnumerable<AnsatQueryResultDto> IAnsatRepository.GetAll()
        {
            foreach (var ansat in _db.AnsatEntities.AsNoTracking().ToList())
            {
                yield return new AnsatQueryResultDto {  Name = ansat.Name, UserId = ansat.UserId, Kompetancer = (ICollection<AnsatKompetanceQueryResultDto>)ansat.Kompetancer, RowVersion = ansat.RowVersion};
            }
        }

        AnsatEntity IAnsatRepository.Load(string userId)
        {
            //Find den Ansat med det givne userId
            var ansat = _db.AnsatEntities.FirstOrDefault(x => x.UserId == userId);

            //Hvis den Ansatte ikke findes, smid en exception
            if (ansat == null) throw new Exception("Ansat Findes Ikke");

            //Load de tilhørende kompetancer til den Ansatte, således at ændringer også påvirker dem
            _db.Entry(ansat).Collection(a => a.Kompetancer).Load();

            //Returnerer den fundne Ansat med deres kompetancer
            return ansat;   
        }

        void IAnsatRepository.Update(AnsatEntity ansat)
        {

            //_db.AnsatEntities.Update(ansat);

            //Gem ændringer på Ansat 
            _db.SaveChanges();
        }
    }
}
