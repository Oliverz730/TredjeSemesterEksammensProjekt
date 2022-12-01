using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSEP.Igangsættelse.Application.Projekt.Repositories;
using TSEP.Igangsættelse.Domain.Model;

namespace TSEP.Igangsættelse.Application.Projekt.Commands.Implementation
{
    public class ProjektCreateCommand : IProjektCreateCommand
    {
        private readonly IProjektRepository _projektRepository;

        public ProjektCreateCommand(IProjektRepository projektRepository)
        {
            _projektRepository = projektRepository;
        }

        void IProjektCreateCommand.Create(ProjektCreateRequestDto projektCreateRequestDto)
        {
            var projekt = new ProjektEntity(
                projektCreateRequestDto.StartDate,
                projektCreateRequestDto.EndDate,
                projektCreateRequestDto.EstimatedTime,
                projektCreateRequestDto.ActualEstimated,
                projektCreateRequestDto.SælgerUserId,
                projektCreateRequestDto.KundeUserId
                );

            _projektRepository.Add(projekt);
        }
    }
}
