
namespace TSEP.Igangsættelse.Application.Projekt.Queries
{
    public interface IProjektGetQuery
    {
        ProjektQueryResultDto Get(int id, string userId);
    }
}
