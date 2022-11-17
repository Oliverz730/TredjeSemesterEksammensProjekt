using TredjeSemesterEksammensProjekt.Infrastructure.Contract.Dto;

namespace TredjeSemesterEksammensProjekt.Infrastructure.Contract
{
    public interface IStamDataService
    {

        Task CreateKompetance(KompetanceCreateRequestDto kompetanceCreateRequestDto);

    }
}
