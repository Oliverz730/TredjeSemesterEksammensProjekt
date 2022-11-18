using TredjeSemesterEksamensProjekt.StamData.Application.Queries;
using TredjeSemesterEksamensProjekt.StamData.Domain.Model;

namespace TredjeSemesterEksamensProjekt.StamData.Application.Repositories
{
    public interface IAnsatRepository
    {
        void Add(AnsatEntity ansat);
        AnsatEntity Load(string userId);
        AnsatQueryResultDto Get(string userId);
        void Update(AnsatEntity ansat);
    }
}
