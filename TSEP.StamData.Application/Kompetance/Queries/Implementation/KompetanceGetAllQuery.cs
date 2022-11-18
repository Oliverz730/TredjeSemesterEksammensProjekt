using TSEP.StamData.Application.Kompetance.Queries;
using TSEP.StamData.Application.Kompetance.Repositories;

namespace TSEP.StamData.Application.Kompetance.Queries.Implementation
{
    public class KompetanceGetAllQuery : IKompetanceGetAllQuery
    {
        private readonly IKompetanceRepository _kompetanceRepository;

        public KompetanceGetAllQuery(IKompetanceRepository kompetanceRepository)
        {
            _kompetanceRepository = kompetanceRepository;
        }

        IEnumerable<KompetanceQueryResultDto> IKompetanceGetAllQuery.GetAll()
        {
            return _kompetanceRepository.GetAll();
        }
    }
}
