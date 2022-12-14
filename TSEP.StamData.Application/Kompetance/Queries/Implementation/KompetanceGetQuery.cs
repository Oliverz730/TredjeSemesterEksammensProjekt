using TSEP.StamData.Application.Kompetance.Queries;
using TSEP.StamData.Application.Kompetance.Repositories;

namespace TSEP.StamData.Application.Kompetance.Queries.Implementation
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
            //Hent KompetanceQueryResultDto fra Repository
            var kompetanceDto = _kompetanceRepository.Get(id);

            //Returnerer den fundne KompetanceQueryResultDto
            return kompetanceDto;
        }
    }
}
