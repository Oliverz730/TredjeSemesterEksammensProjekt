using TredjeSemesterEksamensProjekt.Opgave.Application.Commands;

namespace TredjeSemesterEksammensProjekt.Infrastructure.Contract
{
    public interface IOpgaveService
    {

        Task CreateKompetance(KompetanceCreateRequestDto kompetanceCreateRequestDto);

    }
}
