using TSEP.App.Infrastructure.StamData.Contract.Dto;

namespace TSEP.App.Infrastructure.StamData.Contract
{
    public interface IStamDataService
    {

        Task CreateKompetance(KompetanceCreateRequestDto kompetanceCreateRequestDto);
        Task EditKompetance(KompetanceEditRequestDto kompetanceEditRequestDto);
        Task<IEnumerable<KompetanceQueryResultDto>?> GetAllKompetance();
        Task CreateAnsat(AnsatCreateRequestDto ansatCreateRequestDto);
        Task<AnsatQueryResultDto> GetAnsat(string userId);
        Task EditAnsat(AnsatEditRequestDto ansatEditRequestDto);
        Task<KompetanceQueryResultDto> GetKompetance(int id);

    }
}
