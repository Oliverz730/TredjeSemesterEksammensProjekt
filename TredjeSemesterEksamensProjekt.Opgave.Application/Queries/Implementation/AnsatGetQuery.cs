using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TredjeSemesterEksamensProjekt.Opgave.Application.Repositories;

namespace TredjeSemesterEksamensProjekt.Opgave.Application.Queries.Implementation
{
    public class AnsatGetQuery : IAnsatGetQuery
    {
        private readonly IAnsatRepository _ansatRepository;

        public AnsatGetQuery(IAnsatRepository ansatRepository)
        {
            _ansatRepository = ansatRepository;
        }

        AnsatQueryResultDto IAnsatGetQuery.Get(string UserId)
        {
            return _ansatRepository.Get(UserId);
        }
    }
}
