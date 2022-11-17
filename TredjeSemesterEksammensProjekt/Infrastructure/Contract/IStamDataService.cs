using TredjeSemesterEksammensProjekt.Infrastructure.Contract.Dto;

namespace TredjeSemesterEksammensProjekt.Infrastructure.Contract
{
    public interface IStamDataService
    {

        Task CreateKompetance(KompetanceCreateRequestDto kompetanceCreateRequestDto);
        Task EditKompetance(KompetanceEditRequestDto kompetanceEditRequestDto);
        Task<IEnumerable<KompetanceQueryResultDto>?> GetAllKompetance();
        Task CreateAnsat(AnsatCreateRequestDto ansatCreateRequestDto);
        Task<AnsatQueryResultDto> GetAnsat(string userId);

    }
}
