using TredjeSemesterEksamensProjekt.Opgave.Application.Repositories;
using TredjeSemesterEksamensProjekt.Opgave.Domain.Model;

namespace TredjeSemesterEksamensProjekt.Opgave.Application.Commands.Implementation
{
    public class KompetanceCreateCommand : IKompetanceCreateCommand
    {
        private readonly IKompetanceRepository _kompetanceRepository;

        public KompetanceCreateCommand(IKompetanceRepository kompetanceRepository)
        {
            _kompetanceRepository = kompetanceRepository;
        }

        void IKompetanceCreateCommand.Create(KompetanceCreateRequestDto kompetanceCreateRequestDto)
        {
            var kompetance = new KompetanceEntity(kompetanceCreateRequestDto.Description);
            _kompetanceRepository.Add(kompetance);
        }
    }
}
