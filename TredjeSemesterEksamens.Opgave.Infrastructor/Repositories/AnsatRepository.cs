using TredjeSemesterEksamensProjekt.Opgave.Application.Commands;
using TredjeSemesterEksamensProjekt.Opgave.Application.Repositories;
using TredjeSemesterEksamensProjekt.Opgave.Domain.Model;
using TredjeSemesterEksamensProjekt.SqlDbContextProjekt;
using Microsoft.EntityFrameworkCore;

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

        AnsatEntity IAnsatRepository.Load(int id)
        {
            throw new NotImplementedException();
        }
    }
}
