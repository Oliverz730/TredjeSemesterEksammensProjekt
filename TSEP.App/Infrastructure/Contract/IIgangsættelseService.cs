using TSEP.App.Infrastructure.Contract.Dto;

namespace TSEP.App.Infrastructure.Contract
{
    public interface IIgangsættelseService
    {
        Task CreateProjekt(ProjektCreateRequestDto projektCreateRequestDto);
    }
}
