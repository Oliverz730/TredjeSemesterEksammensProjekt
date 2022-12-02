using TSEP.Igangsættelse.Application.Repositories;
using TSEP.Igangsættelse.Domain.Model;

namespace TSEP.Igangsættelse.Application.OpgaveType.Commands.Implementation
{
    public class OpgaveTypeCreateCommand : IOpgaveTypeCreateCommand
    {
        private readonly IOpgaveTypeRepository _opgaveTypeRepository;

        public OpgaveTypeCreateCommand(IOpgaveTypeRepository opgaveTypeRepository)
        {
            _opgaveTypeRepository = opgaveTypeRepository;
        }

        void IOpgaveTypeCreateCommand.CreateOpgaveType(OpgaveTypeCreateRequestDto opgaveTypeCreateRequestDto)
        {
            var opgaveType = new OpgaveTypeEntity(opgaveTypeCreateRequestDto.Beskrivelse, opgaveTypeCreateRequestDto.KompetanceId);
            _opgaveTypeRepository.Add(opgaveType);
        }
    }
}
