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

        int IProjektCreateCommand.Create(ProjektCreateRequestDto projektCreateRequestDto)
        {
            //opret projekt med givne data
            var projekt = new ProjektEntity(
                projektCreateRequestDto.StartDate,
                projektCreateRequestDto.SælgerUserId,
                projektCreateRequestDto.KundeUserId,
                projektCreateRequestDto.ProjektName
                );
            //tiolføj projekt til repositoriet
            return _projektRepository.Add(projekt);
        }
    }
}
