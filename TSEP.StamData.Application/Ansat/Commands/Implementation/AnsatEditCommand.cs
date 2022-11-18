using TSEP.StamData.Application.Ansat.Repositories;
using TSEP.StamData.Application.Kompetance.Repositories;
using TSEP.StamData.Domain.Model;

namespace TSEP.StamData.Application.Ansat.Commands.Implementation
{
    public class AnsatEditCommand : IAnsatEditCommand
    {

        private readonly IAnsatRepository _ansatRepository;
        private readonly IKompetanceRepository _kompetanceRepository;

        public AnsatEditCommand(IAnsatRepository ansatRepository, IKompetanceRepository kompetanceRepository)
        {
            _ansatRepository = ansatRepository;
            _kompetanceRepository = kompetanceRepository;
        }

        void IAnsatEditCommand.Edit(AnsatEditRequestDto ansatEditRequestDto)
        {
            //Read

            var model = _ansatRepository.Load(ansatEditRequestDto.UserId);
            List<KompetanceEntity> kompetancer = new();

            foreach (var komp in ansatEditRequestDto.Kompetancer)
            {
                kompetancer.Add(_kompetanceRepository.Load(komp.Id));
              
            }


            //Do It
            model.Edit(ansatEditRequestDto.UserId, ansatEditRequestDto.Name, kompetancer);
            

            // Save

            _ansatRepository.Update(model);


        }
    }
}
