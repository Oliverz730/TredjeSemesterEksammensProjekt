using TredjeSemesterEksamensProjekt.StamData.Application.Repositories;
using TredjeSemesterEksamensProjekt.StamData.Domain.Model;

namespace TredjeSemesterEksamensProjekt.StamData.Application.Commands.Implementation
{
    public class AnsatCreateCommand : IAnsatCreateCommand
    {
        private readonly IAnsatRepository _ansatRepository;
        public AnsatCreateCommand(IAnsatRepository ansatRepository)
        {
            _ansatRepository = ansatRepository;
        }

        void IAnsatCreateCommand.Create(AnsatCreateRequestDto ansatCreateRequestDto)
        {
            var ansat = new AnsatEntity(ansatCreateRequestDto.UserId, ansatCreateRequestDto.Name);
            _ansatRepository.Add(ansat);
        }
    }
}
