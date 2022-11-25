using TSEP.StamData.Application.Ansat.Repositories;
using TSEP.StamData.Domain.Model;

namespace TSEP.StamData.Application.Ansat.Commands.Implementation
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
            var ansat = new AnsatEntity(ansatCreateRequestDto.UserId, ansatCreateRequestDto.Name, ansatCreateRequestDto.RowVersion);
            _ansatRepository.Add(ansat);
        }
    }
}
