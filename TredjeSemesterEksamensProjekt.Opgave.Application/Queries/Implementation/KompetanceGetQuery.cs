using TredjeSemesterEksamensProjekt.StamData.Application.Repositories;

namespace TredjeSemesterEksamensProjekt.StamData.Application.Queries.Implementation
{
    public class KompetanceGetQuery : IKompetanceGetQuery
    {
        private readonly IKompetanceRepository _kompetanceRepository;

        public KompetanceGetQuery(IKompetanceRepository kompetanceRepository)
        {
            _kompetanceRepository = kompetanceRepository;
        }

        KompetanceQueryResultDto IKompetanceGetQuery.Get(int id)
        {
            
            var kompetanceDto = _kompetanceRepository.Get(id);

            

            return kompetanceDto;

        }
    }
}
