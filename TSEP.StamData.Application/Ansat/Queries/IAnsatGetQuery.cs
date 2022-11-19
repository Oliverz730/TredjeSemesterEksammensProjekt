namespace TSEP.StamData.Application.Ansat.Queries
{
    public interface IAnsatGetQuery
    {
        AnsatQueryResultDto Get(string UserId);
    }
}
