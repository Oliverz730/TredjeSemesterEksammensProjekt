namespace TredjeSemesterEksamensProjekt.StamData.Application.Queries
{
    public interface IAnsatGetQuery
    {
        AnsatQueryResultDto Get(string UserId);
    }
}
