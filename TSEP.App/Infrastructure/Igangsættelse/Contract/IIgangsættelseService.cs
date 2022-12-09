using TSEP.App.Infrastructure.Igangsættelse.Contract.Dto;

namespace TSEP.App.Infrastructure.Igangsættelse.Contract
{
    public interface IIgangsættelseService
    {
        Task CreateOpgaveType(OpgaveTypeCreateRequestDto opgaveTypeCreateRequestDto);
        Task<IEnumerable<OpgaveTypeQueryResultDto>?> GetAllOpgaveType();
        Task<OpgaveTypeQueryResultDto> GetOpgaveType(int id);

        Task<int> CreateProjekt(ProjektCreateRequestDto projektCreateRequestDto);
        Task<IEnumerable<ProjektQueryResultDto>?> GetAllProjekt(string userId);
        Task<IEnumerable<ProjektQueryResultDto>?> GetAllProjektByKunde(string userId);
        Task<ProjektQueryResultDto?> GetProjekt(int id, string userId);
        Task EditProjekt(ProjektEditRequestDto projektEditRequestDto);

    }
}
