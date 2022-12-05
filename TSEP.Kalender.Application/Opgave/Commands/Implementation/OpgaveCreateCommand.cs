using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSEP.Kalender.Application.Opgave.Repositories;
using TSEP.Kalender.Domain.Model;

namespace TSEP.Kalender.Application.Opgave.Commands.Implementation
{
    public class OpgaveCreateCommand : IOpgaveCreateCommand
    {
        private readonly IOpgaveRepository _opgaveRepository;

        public OpgaveCreateCommand(IOpgaveRepository opgaveRepository)
        {
            _opgaveRepository = opgaveRepository;
        }

        void IOpgaveCreateCommand.Create(OpgaveCreateRequestDto opgaveCreateRequestDto)
        {
            _opgaveRepository.Add(
                new OpgaveEntity
                    (
                    opgaveCreateRequestDto.ProjektId,
                    opgaveCreateRequestDto.OpgaveTypeId,
                    opgaveCreateRequestDto.AnsatId,
                    opgaveCreateRequestDto.Status,
                    opgaveCreateRequestDto.StartTid,
                    opgaveCreateRequestDto.SlutTid
                    )
                );
        }
    }
}
