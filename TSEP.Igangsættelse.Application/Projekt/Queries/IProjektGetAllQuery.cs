
namespace TSEP.Igangsættelse.Application.Projekt.Queries
{
    public interface IProjektGetAllQuery
    {
        IEnumerable<ProjektQueryResultDto> GetAll(string userId);
    }
}
