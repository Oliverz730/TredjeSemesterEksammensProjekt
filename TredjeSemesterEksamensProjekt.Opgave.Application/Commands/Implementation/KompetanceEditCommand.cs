﻿using TredjeSemesterEksamensProjekt.Opgave.Application.Repositories;
using TredjeSemesterEksamensProjekt.Opgave.Domain.Model;

namespace TredjeSemesterEksamensProjekt.Opgave.Application.Commands.Implementation
{
    public class KompetanceEditCommand : IKompetanceEditCommand
    {
        private readonly IKompetanceRepository _kompetanceRepository;

        public KompetanceEditCommand(IKompetanceRepository kompetanceRepository)
        {
            _kompetanceRepository = kompetanceRepository;
        }

        void IKompetanceEditCommand.Edit(KompetanceEditRequestDto kompetanceEditRequestDto)
        {
            var ansatte = kompetanceEditRequestDto.Ansatte.Select(x => new AnsatEntity(x.UserId, x.Name)).ToList();
            var kompetance = new KompetanceEntity(kompetanceEditRequestDto.Description, ansatte);

            _kompetanceRepository.Update(kompetance);
        }
    }
}
