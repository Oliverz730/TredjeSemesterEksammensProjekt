using TredjeSemesterEksamensProjekt.StamData.Application.Repositories;

namespace TredjeSemesterEksamensProjekt.StamData.Application.Queries.Implementation
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
