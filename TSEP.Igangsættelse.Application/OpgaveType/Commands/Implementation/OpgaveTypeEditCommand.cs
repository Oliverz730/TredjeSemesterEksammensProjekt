using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var opgaveEntity = _opgaveTypeRepository.Load(opgaveType.Id);

            //Do it
            opgaveEntity.Edit(opgaveType.Beskrivelse,opgaveType.Id,opgaveType.RowVersion);

            //Save it
            _opgaveTypeRepository.Update(opgaveEntity);

        }
    }
}
