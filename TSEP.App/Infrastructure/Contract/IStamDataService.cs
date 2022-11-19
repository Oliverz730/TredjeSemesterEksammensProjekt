using TSEP.App.Infrastructure.Contract.Dto;

namespace TSEP.App.Infrastructure.Contract
{
    public interface IStamDataService
    {

        Task CreateKompetance(KompetanceCreateRequestDto kompetanceCreateRequestDto);
        Task EditKompetance(KompetanceEditRequestDto kompetanceEditRequestDto);
        Task<IEnumerable<KompetanceQueryResultDto>?> GetAllKompetance();
        Task CreateAnsat(AnsatCreateRequestDto ansatCreateRequestDto);
        Task<AnsatQueryResultDto> GetAnsat(string userId);
        Task EditAnsat(AnsatEditRequestDto ansatEditRequestDto);

    }
}
