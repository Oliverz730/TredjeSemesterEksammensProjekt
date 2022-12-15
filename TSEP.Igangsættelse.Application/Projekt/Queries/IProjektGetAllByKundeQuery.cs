
namespace TSEP.Igangsættelse.Application.Projekt.Queries
{
    public interface IProjektGetAllByKundeQuery
    {
        IEnumerable<ProjektQueryResultDto> GetAllByKunde(string userId);
    }
}
