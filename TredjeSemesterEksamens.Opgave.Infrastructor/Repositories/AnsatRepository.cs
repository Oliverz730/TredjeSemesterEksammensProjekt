using TredjeSemesterEksamensProjekt.Opgave.Application.Commands;
using TredjeSemesterEksamensProjekt.Opgave.Application.Repositories;
using TredjeSemesterEksamensProjekt.Opgave.Domain.Model;
using TredjeSemesterEksamensProjekt.SqlDbContextProjekt;
using Microsoft.EntityFrameworkCore;
using TredjeSemesterEksamensProjekt.Opgave.Application.Queries;

namespace TredjeSemesterEksamensProjekt.Opgave.Infrastructor.Repositories
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
            _db.Add(ansat);
            _db.SaveChanges();
        }

        AnsatQueryResultDto IAnsatRepository.Get(string userId)
        {
            var ansat = _db.AnsatEntities.AsNoTracking().Include(a => a.Kompetancer).FirstOrDefault(a => a.UserId == userId);

            var kompetancer = ansat.Kompetancer.Select(k => new AnsatKompetanceQueryResultDto { Description = k.Description, Id = k.Id }).ToList();

            return new AnsatQueryResultDto
            {
                Name = ansat.Name,
                UserId = ansat.UserId,
                Kompetancer = kompetancer
            };

        }

        AnsatEntity IAnsatRepository.Load(string userId)
        {
            var ansat = _db.AnsatEntities.AsNoTracking().Include(a => a.Kompetancer).FirstOrDefault(x => x.UserId == userId);

            if (ansat == null) throw new Exception("Ansat Findes Ikke");

            return ansat;   
        }

        void IAnsatRepository.Update(AnsatEntity ansat)
        {
            _db.AnsatEntities.Update(ansat);
            _db.SaveChanges();
        }
    }
}
