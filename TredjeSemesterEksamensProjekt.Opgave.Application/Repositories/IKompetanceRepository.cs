using TredjeSemesterEksamensProjekt.StamData.Application.Queries;
using TredjeSemesterEksamensProjekt.StamData.Domain.Model;

namespace TredjeSemesterEksamensProjekt.StamData.Application.Repositories
{
    public interface IKompetanceRepository
    {
        void Add(KompetanceEntity kompetance);
        KompetanceEntity Load(int id);
        KompetanceQueryResultDto Get(int id);
       IEnumerable<KompetanceQueryResultDto> GetAll();


        void Update(KompetanceEntity kompetance);
    }
}
