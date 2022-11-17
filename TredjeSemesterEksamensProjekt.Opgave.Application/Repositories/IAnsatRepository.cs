using TredjeSemesterEksamensProjekt.Opgave.Application.Queries;
using TredjeSemesterEksamensProjekt.Opgave.Domain.Model;

namespace TredjeSemesterEksamensProjekt.Opgave.Application.Repositories
{
    public interface IAnsatRepository
    {
        void Add(AnsatEntity ansat);
        AnsatEntity Load(int id);
        AnsatQueryResultDto Get(string userId);
    }
}
