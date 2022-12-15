using TSEP.Igangsættelse.Application.OpgaveType.Repositories;
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
            //Opret opgave med givne data
            var opgaveType = new OpgaveTypeEntity(opgaveTypeCreateRequestDto.Beskrivelse, opgaveTypeCreateRequestDto.KompetanceId);
            //Tilføj data til repositoriet
            _opgaveTypeRepository.Add(opgaveType);
        }
    }
}
