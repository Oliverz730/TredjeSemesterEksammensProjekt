using TSEP.StamData.Application.Ansat.Repositories;

namespace TSEP.StamData.Application.Ansat.Queries.Implementation
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
            //Return den fundne ansatdto fra repository
            return _ansatRepository.Get(UserId);
        }
    }
}
