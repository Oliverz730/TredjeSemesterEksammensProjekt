using TSEP.StamData.Application.Kompetance.Commands;
using TSEP.StamData.Application.Kompetance.Repositories;
using TSEP.StamData.Domain.Model;

namespace TSEP.StamData.Application.Kompetance.Commands.Implementation
{
    public class KompetanceEditCommand : IKompetanceEditCommand
    {
        private readonly IKompetanceRepository _kompetanceRepository;

        public KompetanceEditCommand(IKompetanceRepository kompetanceRepository)
        {
            _kompetanceRepository = kompetanceRepository;
        }

        void IKompetanceEditCommand.Edit(KompetanceEditRequestDto kompetanceEditRequestDto)
        {
            var ansatte = kompetanceEditRequestDto.Ansatte.Select(x => new AnsatEntity(x.UserId, x.Name,x.RowVersion)).ToList();
            var kompetance = new KompetanceEntity(kompetanceEditRequestDto.Description, ansatte, kompetanceEditRequestDto.RowVersion);

            _kompetanceRepository.Update(kompetance);
        }
    }
}
