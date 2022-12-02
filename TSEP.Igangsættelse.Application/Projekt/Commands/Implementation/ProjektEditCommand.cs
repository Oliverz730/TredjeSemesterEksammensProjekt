using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var model= _projektRepository.Load(editRequestDto.Id );

            model.Edit( editRequestDto.StartDate, editRequestDto.EndDate, editRequestDto.EstimatedTime, editRequestDto.ActualEstimated, editRequestDto.KundeUserId, editRequestDto.ProjektName,editRequestDto.RowVersion);
            
            _projektRepository.Update(model);
        }
    }
}
