namespace TredjeSemesterEksamensProjekt.StamData.Application.Queries
{
    public interface IKompetanceGetAllQuery
    {
        IEnumerable<KompetanceQueryResultDto> GetAll();
    }
}
