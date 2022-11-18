using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TredjeSemesterEksamensProjekt.Opgave.Application.Repositories;

namespace TredjeSemesterEksamensProjekt.Opgave.Application.Queries.Implementation
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
