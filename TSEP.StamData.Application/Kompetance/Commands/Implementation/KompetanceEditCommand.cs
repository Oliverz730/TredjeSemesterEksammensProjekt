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
            var model = _kompetanceRepository.Load(kompetanceEditRequestDto.Id);
            List<AnsatEntity> ansatte = new();

            foreach (var ans in kompetanceEditRequestDto.Ansatte)
            {
                ansatte.Add(_ansatRepository.Load(ans.UserId));
            }



            _kompetanceRepository.Update(model);
        }
    }
}
