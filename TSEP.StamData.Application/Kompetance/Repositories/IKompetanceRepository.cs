using TSEP.StamData.Application.Kompetance.Queries;
using TSEP.StamData.Domain.Model;

namespace TSEP.StamData.Application.Kompetance.Repositories
{
    public interface IKompetanceRepository
    {
        void Add(KompetanceEntity kompetance);
        KompetanceEntity LoadWithTracking(int id);
        KompetanceEntity LoadWithoutTracking(int id);
        KompetanceQueryResultDto Get(int id);
        IEnumerable<KompetanceQueryResultDto> GetAll();
        void Update(KompetanceEntity kompetance);
    }
}
