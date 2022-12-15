using TSEP.Igangsættelse.Application.Projekt.Queries;
using TSEP.Igangsættelse.Domain.Model;

namespace TSEP.Igangsættelse.Application.Projekt.Repositories
{
    public interface IProjektRepository
    {
        int Add(ProjektEntity projekt);
        ProjektEntity Load(int id);
        ProjektQueryResultDto Get(int id, string userId);
        IEnumerable<ProjektQueryResultDto> GetAll(string userId);
        IEnumerable<ProjektQueryResultDto> GetAllByKunde(string userId);
        void Update(ProjektEntity projekt);
    }
}
