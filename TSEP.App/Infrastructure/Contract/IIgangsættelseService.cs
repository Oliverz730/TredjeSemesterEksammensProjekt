using TSEP.App.Infrastructure.Contract.Dto;

namespace TSEP.App.Infrastructure.Contract
{
    public interface IIgangsættelseService
    {
        Task CreateProjekt(ProjektCreateRequestDto projektCreateRequestDto);
        Task<IEnumerable<ProjektQueryResultDto>?> GetAllProjekt(string userId);
        Task<ProjektQueryResultDto?> GetProjekt(int id,string userId);
        Task EditProjekt(ProjektEditRequestDto projektEditRequestDto);

    }
}
