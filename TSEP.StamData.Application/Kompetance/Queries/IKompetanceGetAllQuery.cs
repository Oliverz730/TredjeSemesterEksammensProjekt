namespace TSEP.StamData.Application.Kompetance.Queries
{
    public interface IKompetanceGetAllQuery
    {
        IEnumerable<KompetanceQueryResultDto> GetAll();
    }
}
