using TSEP.StamData.Application.Kompetance.Commands;
using TSEP.StamData.Application.Kompetance.Repositories;
using TSEP.StamData.Domain.Model;

namespace TSEP.StamData.Application.Kompetance.Commands.Implementation
{
    public class KompetanceCreateCommand : IKompetanceCreateCommand
    {
        private readonly IKompetanceRepository _kompetanceRepository;

        public KompetanceCreateCommand(IKompetanceRepository kompetanceRepository)
        {
            _kompetanceRepository = kompetanceRepository;
        }

        void IKompetanceCreateCommand.Create(KompetanceCreateRequestDto kompetanceCreateRequestDto)
        {
            //Opræt Kompetance med de givne data
            var kompetance = new KompetanceEntity(kompetanceCreateRequestDto.Description);

            //Tilføj Kompetancen til Repositoriet
            _kompetanceRepository.Add(kompetance);
        }
    }
}
