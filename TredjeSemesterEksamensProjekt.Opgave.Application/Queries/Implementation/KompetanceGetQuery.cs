using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TredjeSemesterEksamensProjekt.Opgave.Application.Repositories;

namespace TredjeSemesterEksamensProjekt.Opgave.Application.Queries.Implementation
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
