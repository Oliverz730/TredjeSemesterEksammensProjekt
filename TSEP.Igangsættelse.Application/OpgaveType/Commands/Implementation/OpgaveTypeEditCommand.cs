using TSEP.Igangsættelse.Application.OpgaveType.Repositories;

namespace TSEP.Igangsættelse.Application.OpgaveType.Commands.Implementation
{
    public class OpgaveTypeEditCommand : IOpgaveTypeEditCommand
    {

        private readonly IOpgaveTypeRepository _opgaveTypeRepository;

        public OpgaveTypeEditCommand(IOpgaveTypeRepository opgaveTypeRepository)
        {
            _opgaveTypeRepository = opgaveTypeRepository;
        }
        void IOpgaveTypeEditCommand.Edit(OpgaveTypeEditRequestDto opgaveType)
        {
            //Read it
            //indlæs data fra repository
            var opgaveEntity = _opgaveTypeRepository.Load(opgaveType.Id);

            //Do it
            //Tilføj ændringer
            opgaveEntity.Edit(opgaveType.Beskrivelse,opgaveType.Id,opgaveType.RowVersion);

            //Save it
            //gem ændringer i repository
            _opgaveTypeRepository.Update(opgaveEntity);

        }
    }
}
