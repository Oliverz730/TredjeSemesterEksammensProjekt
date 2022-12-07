using TSEP.StamData.Application.Ansat.Queries;
using TSEP.StamData.Domain.Model;

namespace TSEP.StamData.Application.Ansat.Repositories
{
    public interface IAnsatRepository
    {
        void Add(AnsatEntity ansat);
        AnsatEntity Load(string userId);
        AnsatQueryResultDto Get(string userId);
        void Update(AnsatEntity ansat);
        IEnumerable<AnsatQueryResultDto> GetAll();
    }
}
