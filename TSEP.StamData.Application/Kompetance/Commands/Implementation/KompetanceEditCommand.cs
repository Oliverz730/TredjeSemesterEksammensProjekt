using TSEP.StamData.Application.Ansat.Repositories;
using TSEP.StamData.Application.Kompetance.Commands;
using TSEP.StamData.Application.Kompetance.Repositories;
using TSEP.StamData.Domain.Model;

namespace TSEP.StamData.Application.Kompetance.Commands.Implementation
{
    public class KompetanceEditCommand : IKompetanceEditCommand
    {
        private readonly IKompetanceRepository _kompetanceRepository;
        private readonly IAnsatRepository _ansatRepository;

        public KompetanceEditCommand(IKompetanceRepository kompetanceRepository, IAnsatRepository ansatRepository)
        {
            _kompetanceRepository = kompetanceRepository;
            _ansatRepository = ansatRepository;
        }

        void IKompetanceEditCommand.Edit(KompetanceEditRequestDto kompetanceEditRequestDto)
        {
            //Read It
            //indlæs data fra repository
            var model = _kompetanceRepository.LoadWithoutTracking(kompetanceEditRequestDto.Id);
            //List<AnsatEntity> ansatte = kompetanceEditRequestDto.Ansatte.Select(a => _ansatRepository.Load(a.UserId) ).ToList();

            //Do It
            //tilføj ændringer
            //model.Edit(kompetanceEditRequestDto.Description, ansatte, kompetanceEditRequestDto.RowVersion);
            model.Edit(kompetanceEditRequestDto.Description, kompetanceEditRequestDto.RowVersion);

            //Save It
            //Gem ændringer i repository
            _kompetanceRepository.Update(model);
        }
    }
}
