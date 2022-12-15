using TSEP.Igangsættelse.Application.Projekt.Repositories;
using TSEP.Igangsættelse.Domain.Model;
using TSEP.Igangsættelse.Application.Projekt.Commands;

namespace TSEP.Igangsættelse.Application.Projekt.Commands.Implementation
{
    public class ProjektEditCommand : IProjektEditCommand
    { 
        private readonly IProjektRepository _projektRepository;

        public ProjektEditCommand(IProjektRepository projektRepository)
        {
            _projektRepository = projektRepository;
        }

        void IProjektEditCommand.Edit(ProjektEditRequestDto editRequestDto)
        {
            //Read it
            //Indlæs data fra repository
            var model= _projektRepository.Load(editRequestDto.Id );

            //Do it
            //tilføj ændringer 
            model.Edit( editRequestDto.StartDate, editRequestDto.EndDate, editRequestDto.EstimatedTime, editRequestDto.ActualEstimated, editRequestDto.KundeUserId, editRequestDto.ProjektName,editRequestDto.RowVersion);
            
            //Save it
            // gem ændringer i repository
            _projektRepository.Update(model);
        }
    }
}
