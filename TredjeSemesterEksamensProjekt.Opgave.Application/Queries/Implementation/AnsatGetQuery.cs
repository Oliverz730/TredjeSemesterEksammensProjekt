using TredjeSemesterEksamensProjekt.StamData.Application.Repositories;

namespace TredjeSemesterEksamensProjekt.StamData.Application.Queries.Implementation
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
