using TredjeSemesterEksamensProjekt.Opgave.Application.Queries;
using TredjeSemesterEksamensProjekt.Opgave.Domain.Model;

namespace TredjeSemesterEksamensProjekt.Opgave.Application.Repositories
{
    public interface IKompetanceRepository
    {
        void Add(KompetanceEntity kompetance);
        KompetanceEntity Load(int id);
        KompetanceQueryResultDto Get(int id);
    }
}
