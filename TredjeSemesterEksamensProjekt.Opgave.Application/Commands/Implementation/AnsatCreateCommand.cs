using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TredjeSemesterEksamensProjekt.Opgave.Application.Repositories;
using TredjeSemesterEksamensProjekt.Opgave.Domain.Model;

namespace TredjeSemesterEksamensProjekt.Opgave.Application.Commands.Implementation
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
